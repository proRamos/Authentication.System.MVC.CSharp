using Nanosoft.Email;
using System;
using System.Text.Encodings.Web;

namespace SendEmailTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginToEmail AdminUser = new LoginToEmail("name@mail.com", "******");

            AdminUser.SendNewEmail(
                "ramosprotasio@gmail.com",
                "Confirm your email",
                $"Please confirm your account by <a href='www...'>clicking here</a>.",
                true
                );
        }
    }
}
