using DTLoanManagment.Models.Common;
using DTLoanManagment.Models.Loan;

namespace DTLoanManagment.Repository.Interfaces
{
    public interface ILoanGateway
    {
        Task<MessageResponse?> ApproveLoan(SetLoanEmi setLoanEmiRequest);
        Task<bool> DisburseLoan(int loanId);
        Task<SetLoanEmi?> GetLoanInfoByLoanSurveyId(int loanSurveyId);
        Task<SetLoanEmi?> GetMerchantWiseApprovedLoans(int courierUserId);
        Task<IEnumerable<SetLoanEmi>> GetUnApprovedLoans();
        Task<MessageResponse> RejectLoan(SetLoanEmi setLoanEmiRequest);
        Task<MessageResponse> SaveLoanEmi(SetLoanEmi setLoanEmiRequest);
    }
}
