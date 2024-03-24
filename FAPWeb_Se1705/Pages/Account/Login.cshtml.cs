using FAPWeb_Se1705.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace FAPWeb_Se1705.Pages.Authentication
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private FAPPRJContext context;
        public string Message { get; set; }

        [BindProperty]
        public User UserLogin { get; set; }

        public LoginModel(FAPPRJContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            User userCheck = new User();

            userCheck = context.Users
                .Include((u) => u.Role)
                .FirstOrDefault((u) => u.Email.Equals(UserLogin.Email) && u.Password.Equals(UserLogin.Password));
            if (userCheck != null)
            {

                String email = userCheck.Email.Trim();
                String role = userCheck.Role.RoleName.Trim();
                var claims = new List<Claim>()
              {
                  new Claim(ClaimTypes.Name, email),
                  new Claim(ClaimTypes.Role,role),
                  //new Claim(ClaimTypes.Role,"TEACHER")
              };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = true
                });
                return Redirect("/Timetable");

            }
            else
            {
         
                Message = "Email or password is incorrect";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to login page    
            return Redirect("/Account/Login");
        }
    }
}
