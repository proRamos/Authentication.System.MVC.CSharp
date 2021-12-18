using System;
using Auth.System.MVC.WebApp.Areas.Identity.Data;
using Auth.System.MVC.WebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Auth.System.MVC.WebApp.Areas.Identity.IdentityHostingStartup))]
namespace Auth.System.MVC.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthSystemMVCWebAppDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthSystemMVCWebAppDbContextConnection")));

                services.AddDefaultIdentity<AuthSystemMVCWebAppUser>(options =>{
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    }
                )
                    .AddEntityFrameworkStores<AuthSystemMVCWebAppDbContext>();
            });
        }
    }
}