using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Auth.System.MVC.WebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AuthSystemMVCWebAppUser class
    public class AuthSystemMVCWebAppUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string SecondName { get; set; }
    }
}
