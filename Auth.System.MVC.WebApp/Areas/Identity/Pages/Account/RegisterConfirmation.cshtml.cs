﻿using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Auth.System.MVC.WebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nanosoft.Email;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;

namespace Auth.System.MVC.WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private const string BodyConfirmMsg = "<p><a id=\"confirm-link\" href=\"@Model.EmailConfirmationUrl\">Click here to confirm your account</a></p>";
        private readonly UserManager<AuthSystemMVCWebAppUser> _userManager;
        private readonly IEmailSender _sender;

        public RegisterConfirmationModel(UserManager<AuthSystemMVCWebAppUser> userManager, IEmailSender sender)
        {
            _userManager = userManager;
            _sender = sender;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;

            DisplayConfirmAccountLink = false;


            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            
            EmailConfirmationUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                protocol: Request.Scheme);



            LoginToEmail AdminUser = new LoginToEmail("name@mail.com", "******"); 

            AdminUser.SendNewEmail(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{EmailConfirmationUrl}'>clicking here</a>.",
                true
                );

// 
            return Page();
        }


    }

}
