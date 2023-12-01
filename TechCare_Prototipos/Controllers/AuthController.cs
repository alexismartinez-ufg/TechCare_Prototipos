using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.ViewModels;
using System.Security.Claims;

namespace TechCare_Prototipos.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly IUsuariosRepository usuariosRepository;
        private readonly IZonasRepository zonasRepository;
        private readonly IMesasRepository mesasRepository;

        public AuthController(IAuthService _authService, IUsuariosRepository _usuariosRepository, IZonasRepository _zonasRepository, IMesasRepository _mesasRepository)
        {
            authService = _authService;
            usuariosRepository = _usuariosRepository;
            zonasRepository = _zonasRepository;
            mesasRepository = _mesasRepository;
        }

        public async Task<IActionResult> Index()
        {
            await Seed.SeedUsers(usuariosRepository);
            await Seed.SeedZonas(zonasRepository);
            await Seed.SeedMesas(mesasRepository);
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

                var role = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value ?? "default";

                return RedirectToAction(ViewsByRole.Dictionary[role].Action, ViewsByRole.Dictionary[role].Controller);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        public IActionResult Denied() => View();
    }
}
