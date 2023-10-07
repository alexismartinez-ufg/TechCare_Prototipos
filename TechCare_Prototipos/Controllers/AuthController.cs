using Microsoft.AspNetCore.Mvc;

namespace TechCare_Prototipos.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index() => RedirectToAction("Login");

        public IActionResult Login()
        {
            return View();
        }
    }
}
