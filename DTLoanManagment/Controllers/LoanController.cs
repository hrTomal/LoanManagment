using DTLoanManagment.Models.Common;
using DTLoanManagment.Models.Common.Response;
using DTLoanManagment.Models.Loan;
using DTLoanManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTLoanManagment.Controllers
{
    [Authorize]
    public class LoanController : Controller
    {
        private readonly ILoanGateway _loanGateway;
        public LoanController(ILoanGateway loanGateway)
        {
            this._loanGateway = loanGateway;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetLoanEMI()
        {
            return View();
        }
        public IActionResult ShowSavedLoanEMIs()
        {
            return View();
        }

        [Route("~/api/SaveLoanEmi/")]
        [HttpPost]
        public async Task<ActionResult> SaveLoanEmi([FromBody] SetLoanEmi setLoanEmiRequest)
        {
            var response = new SingleResponseModel<dynamic>(200);
            response.Model = await _loanGateway.SaveLoanEmi(setLoanEmiRequest);
            return Ok(response);
        }
        [Route("~/api/GetUnApprovedLoans/")]
        [HttpGet]
        public async Task<ActionResult> GetUnApprovedLoans()
        {
            var response = new ListResponseModel<SetLoanEmi>(200);
            response.Model = await _loanGateway.GetUnApprovedLoans();
            return Ok(response);
        }
        [Route("~/api/ApproveLoan/")]
        [HttpPost]
        public async Task<ActionResult> ApproveLoan([FromBody] SetLoanEmi setLoanEmiRequest)
        {
            var response = new SingleResponseModel<MessageResponse>(200);
            response.Model = await _loanGateway.ApproveLoan(setLoanEmiRequest);
            return Ok(response);
        }
        [Route("~/api/RejectLoan/")]
        [HttpPost]
        public async Task<ActionResult> RejectLoan([FromBody] SetLoanEmi setLoanEmiRequest)
        {
            var response = new SingleResponseModel<MessageResponse>(200);
            response.Model = await _loanGateway.RejectLoan(setLoanEmiRequest);
            return Ok(response);
        }
        [AllowAnonymous]
        [Route("~/api/GetMerchantWiseApprovedLoans/{courierUserId}")]
        [HttpGet]
        public async Task<ActionResult> GetMerchantWiseApprovedLoans(int courierUserId)
        {
            var response = new SingleResponseModel<SetLoanEmi>(200);
            response.Model = await _loanGateway.GetMerchantWiseApprovedLoans(courierUserId);
            return Ok(response);
        }
        [AllowAnonymous]
        [Route("~/api/GetLoanInfoByLoanSurveyId/{loanSurveyId}")]
        [HttpGet]
        public async Task<ActionResult> GetLoanInfoByLoanSurveyId(int loanSurveyId)
        {
            var response = new SingleResponseModel<SetLoanEmi>(200);
            response.Model = await _loanGateway.GetLoanInfoByLoanSurveyId(loanSurveyId);
            return Ok(response);
        }
        [AllowAnonymous]
        [Route("~/api/DisburseLoan/{loanId}")]
        [HttpGet]
        public async Task<ActionResult> DisburseLoan(int loanId)
        {
            var response = new SingleResponseModel<MessageResponse>(200);
            
            var res = await _loanGateway.DisburseLoan(loanId);
            if(res == true)
            {
                response.Message = "OK";
            }
            else
            {
                response.Message = "Error";
            }
            return Ok(response);
        }
    }
}
