using DTLoanManagment.Models.Account;
using DTLoanManagment.Models.Common;
using DTLoanManagment.Models.DBContext;
using DTLoanManagment.Models.Loan;
using DTLoanManagment.Models.RequestModels.Loan;
using DTLoanManagment.Models.ResponseModels;
using DTLoanManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

namespace DTLoanManagment.Repository.Gateway.Loan
{
    public class LoanGateway : ILoanGateway
    {
        private readonly MainDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoanGateway(DbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _context = dbContext as MainDBContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<MessageResponse?> ApproveLoan(SetLoanEmi setLoanEmiRequest)
        {
            var msg = new MessageResponse();
            var entity = await _context.SetLoanEmi.FirstOrDefaultAsync(e => e.BorrowerId == setLoanEmiRequest.BorrowerId && e.isApproved == false && e.isRejected == false && e.isActive == true);
            if (entity != null)
            {
                entity.isApproved = true;
                _context.SaveChanges();
                msg.Message = "Approved";
            }
            else
            {
                msg.Message = "Error";
            }
            return msg;
        }        

        public async Task<SetLoanEmi?> GetMerchantWiseApprovedLoans(int courierUserId)
        {
            var res = new SetLoanEmi();
            var entity = await _context.SetLoanEmi.FirstOrDefaultAsync(e => e.BorrowerId == courierUserId && e.isApproved == true);
            if(entity != null)
            {
                res = entity;
            }
            return res;
        }

        public async Task<IEnumerable<SetLoanEmi>> GetUnApprovedLoans()
        {
            var results = await _context.SetLoanEmi.Where(o => o.isApproved == false && o.isRejected == false).ToListAsync();

            foreach (var obj in results)
            {
                obj.InstallmentType = obj.InstallmentType == "1" ? "Monthly" : "Weekly";
            }

            return results;
        }

        public async Task<MessageResponse> RejectLoan(SetLoanEmi setLoanEmiRequest)
        {
            var msg = new MessageResponse();
            var entity = await _context.SetLoanEmi.FirstOrDefaultAsync(e => e.BorrowerId == setLoanEmiRequest.BorrowerId && e.isApproved == false);
            if (entity != null)
            {
                entity.isRejected = true;
                _context.SaveChanges();
                msg.Message = "Rejected";
            }
            return msg;
        }

        public async Task<MessageResponse> SaveLoanEmi(SetLoanEmi setLoanEmiRequest)
        {
            MessageResponse responseMsg = new MessageResponse();
            var currentUser = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            setLoanEmiRequest.CreatedBy = currentUser;
            setLoanEmiRequest.CreatedAt = DateTime.Now;
            setLoanEmiRequest.UpdatedBy = currentUser;
            setLoanEmiRequest.UpdatedAt = DateTime.Now;

            var ifExists = await _context.SetLoanEmi.FirstOrDefaultAsync(o => o.BorrowerId == setLoanEmiRequest.BorrowerId);

            if (ifExists == null) {
                setLoanEmiRequest.isActive = true;
                _context.SetLoanEmi.Add(setLoanEmiRequest);
                responseMsg.Message = "EMI Set Successfull";
            }
            else {
                if(ifExists.isActive)
                {
                    responseMsg.Message = "There is an active loan for this user.";
                }
                else
                {
                    setLoanEmiRequest.isActive = true;
                    _context.SetLoanEmi.Add(setLoanEmiRequest);
                    responseMsg.Message = "EMI Set Successfull";
                }
            }
            await _context.SaveChangesAsync();

            return responseMsg;
        }

        public async Task<bool> DisburseLoan(int loanId)
        {
            LenderUserResponse loginResponse = await AdCoreLogin();
            string jwtForSojon = loginResponse.Model.Token;

            var isDisbursed = await UpdateLoanDisbursementDT(loanId,jwtForSojon) ;

            return isDisbursed;
        }

        public async Task<LenderUserResponse> AdCoreLogin()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://adcore.ajkerdeal.com/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            AdcoreLogin loginData = new AdcoreLogin
            {
                UserName = "SojonTest",
                Password = "123"
            };

            LenderUserResponse? user = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("Account/LenderUserLogin", loginData);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<LenderUserResponse>();
                //var res = response.Content.ReadAsStringAsync();
            }
            return user;

        }

        public async Task<bool> UpdateLoanDisbursementDT(int loanId, string token)
        {
            LoanDisbursementDT loanDisbursementDT;
            var entity = await _context.SetLoanEmi.FirstOrDefaultAsync(e => e.LoanSurveyId == loanId && e.isApproved == true);
            if (entity != null)
            {
                loanDisbursementDT = new LoanDisbursementDT()
                {                            
                    TransactionID = "",
                    DisbursementAmount = entity.LoanAmount,
                    DisbursementDate = DateTime.Now,
                    EmiAmount = entity.PrincipalWithInterestAmountEMI,
                    EmiDay = "15",
                    CumulativeRecovery = 0,
                    LastMonthRecoveryAmount = 0,
                    MonthlyMaxEmiDate = "15",
                    LoanApplicationId = entity.LoanSurveyId,
                    LoanDuration = entity.Tenure,
                    StatusCode = "00004",
                    Status = "Open"
                };

                var client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:58676/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.PostAsJsonAsync("Loan/UpdateLoanDisbursementDT", loanDisbursementDT);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<LoanDisbursementResponse>();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<SetLoanEmi?> GetLoanInfoByLoanSurveyId(int loanSurveyId)
        {
            var res = new SetLoanEmi();
            var entity = await _context.SetLoanEmi.FirstOrDefaultAsync(e => e.LoanSurveyId == loanSurveyId);
            if (entity != null)
            {
                res = entity;
            }
            return res;
        }
    }
}
