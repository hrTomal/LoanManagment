using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DTLoanManagment.Areas.Identity.Data;

// Add profile data for application users by adding properties to the DTLoanManagmentUser class
public class DTLoanManagmentUser : IdentityUser
{
    public string FullName { get; set; }
}

