using DTLoanManagment.Models.Common;
using DTLoanManagment.Models.DBContext;
using DTLoanManagment.Models.Loan;
using DTLoanManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DTLoanManagment.Repository.Gateway.Report
{
    public class ReportGateway : IReportGateway
    {
        private readonly MainDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReportGateway(DbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _context = dbContext as MainDBContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<SetLoanEmi>> GetApprovedLoans()
        {
            var results = await _context.SetLoanEmi.Where(o => o.isApproved == true && o.isRejected == false).ToListAsync();

            foreach (var obj in results)
            {
                obj.InstallmentType = obj.InstallmentType == "1" ? "Monthly" : "Weekly";
            }

            return results;
        }

       
    }
}
