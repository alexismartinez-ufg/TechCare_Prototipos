using Microsoft.AspNetCore.Mvc;

namespace TechCare_Prototipos.Controllers
{
    public class Administracion : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }
    }
}
