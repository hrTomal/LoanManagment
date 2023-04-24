using DTLoanManagment.Areas.Identity.Data;
using DTLoanManagment.Constants;
using Microsoft.AspNetCore.Identity;

namespace DTLoanManagment.Services
{
    public class DBSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<DTLoanManagmentUser>>();
            //var roleManager = service.GetService<RoleManager<IdentityRole>>();
            //await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.AssistantManager.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.SrExecutive.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.Executive.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.MerchantBased.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.RiderBased.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.DataAnalyst.ToString()));
            //await roleManager.CreateAsync(new IdentityRole(Roles.NewJoiner.ToString()));

            var user = new DTLoanManagmentUser{ 
                FullName = "New Super Admin",
                Email = "tester@bdjobs.com",
                UserName= "testuser",
                EmailConfirmed= true,
                PhoneNumber = "0123456789"
            };

            var userInDB = await userManager.FindByEmailAsync(user.Email);
            if (userInDB == null)
            {
                await userManager.CreateAsync(user, "Test@123");
                await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
            }
        }
    }
}
