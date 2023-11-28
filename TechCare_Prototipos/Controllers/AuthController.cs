using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechCare_Prototipos.ViewModels;

namespace TechCare_Prototipos.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index() => RedirectToAction("Login");

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model.UserName == "alexis@alexis.alexis" && model.Password == "1234")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, "administrador")
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                return RedirectToAction("Servicios");
            }

            return View();
        }

        public IActionResult Logout() => View();
    }
}
