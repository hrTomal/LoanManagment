using DTLoanManagment.Models.Common;
using DTLoanManagment.Models.Loan;

namespace DTLoanManagment.Repository.Interfaces
{
    public interface IReportGateway
    {
        Task<IEnumerable<SetLoanEmi>> GetApprovedLoans();
    }
}
