using Microsoft.AspNetCore.Mvc;

namespace TechCare_Prototipos.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Venta()
        {
            return View();
        }
    }
}
