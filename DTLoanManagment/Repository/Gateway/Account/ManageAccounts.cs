using DTLoanManagment.Models.DBContext;
using DTLoanManagment.Models.ViewModels;

namespace DTLoanManagment.Repository.Gateway.Account
{
    public class ManageAccounts
    {
        private readonly MainDBContext _context;

        public ManageAccounts(MainDBContext context)
        {
            _context = context;
        }
        public IEnumerable<UserRolesViewModel> GetAllUsers()
        {
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      FullName = user.UserName,
                                      user.Email
                                  }).ToList().Select(p => new UserRolesViewModel()

                                  {
                                      UserId = p.UserId,
                                      FullName = p.FullName,
                                      Email = p.Email
                                  });
            return usersWithRoles;
        }
    }
}
