using DTLoanManagment.Models.DBTableModels;
using DTLoanManagment.Models.DBTableModels.Journal;
using DTLoanManagment.Models.Loan;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DTLoanManagment.Models.DBContext
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions<MainDBContext> options)
        : base(options)
        {            
        }
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<SetLoanEmi> SetLoanEmi { get; set; }
        public DbSet<Journal> Journal { get; set; }
        public DbSet<Ledger> Ledger { get; set; }
    }
}
