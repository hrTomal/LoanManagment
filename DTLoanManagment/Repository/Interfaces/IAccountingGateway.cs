using DTLoanManagment.Models.Accounting;
using DTLoanManagment.Models.DBTableModels.Journal;

namespace DTLoanManagment.Repository.Interfaces
{
    public interface IAccountingGateway
    {
        Task<IEnumerable<Ledger>> GetMainLedgers();
        Task<IEnumerable<Ledger>> GetSubGroupLedgers(string ledgerIds, int levelNo);
    }
}
