using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Projet_Web_Pizza.Pages.Admin
{

    public class IndexModel : PageModel
    {
        public bool HasErrors = false;

        IConfiguration configuration;
        public  IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult OnGet()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Pizzas");
            }

            return Page();
        }


        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
          var authSection =  configuration.GetSection("Auth");

            string AmdinLogin = authSection["AdminLogin"];
            string AmdinPassword = authSection["AdminPassword"];


            if (username == AmdinLogin && password== AmdinPassword)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
                

            }
            HasErrors = true;
            return Page();
        }
        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}