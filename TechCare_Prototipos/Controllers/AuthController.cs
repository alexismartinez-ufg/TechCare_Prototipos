using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.ViewModels;
using System.Security.Claims;

namespace TechCare_Prototipos.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly IUsuariosRepository usuariosRepository;

        public AuthController(IAuthService _authService, IUsuariosRepository _usuariosRepository)
        {
            authService = _authService;
            usuariosRepository = _usuariosRepository;
        }

        public async Task<IActionResult> Index()
        {
            await Seed.SeedUsers(usuariosRepository);
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {            
            if(authService.TryLogin(model, out ClaimsPrincipal claimsPrincipal))
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Servicios");
            }

            return View();
        }

        public IActionResult Logout() => View();
        public IActionResult Denied() => View();
    }
}
