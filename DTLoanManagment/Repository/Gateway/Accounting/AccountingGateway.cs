using DTLoanManagment.Models.Accounting;
using DTLoanManagment.Models.DBContext;
using DTLoanManagment.Models.DBTableModels.Journal;
using DTLoanManagment.Models.Loan;
using DTLoanManagment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DTLoanManagment.Repository.Gateway.Accounting
{
    public class AccountingGateway : IAccountingGateway
    {
        private readonly MainDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountingGateway(MainDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<IEnumerable<Ledger>> GetMainLedgers()
        {
            try
            {
                var results = await _context.Ledger.Where(e => e.LevelNo == 0).ToListAsync();
                return results;
            }catch(Exception ex) {

                return null;
            }
            
        }
        public async Task<IEnumerable<Ledger>> GetSubGroupLedgers(string ledgerIds, int levelNo)
        {
            try
            {
                string[] delimiters = { "," };
                var searchQuery = await _context.Ledger.Where(l => EF.Functions.Like("," + l.Under + ",", "%,"+ledgerIds+",%"))
                                                        .Where(l => l.LevelNo == levelNo)
                                                        .ToListAsync(); 

                //List<Ledger> results = await _context.Ledger.Where(e => e.LevelNo == 1 && e.Under.Split(",").Any(x => x.Contains(ledgerIds))).ToListAsync();
                return searchQuery;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
