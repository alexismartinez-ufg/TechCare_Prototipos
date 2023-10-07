using Microsoft.AspNetCore.Mvc;

namespace TechCare_Prototipos.Controllers
{
    public class ReservaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Exitosa()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
