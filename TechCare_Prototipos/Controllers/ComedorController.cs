using Microsoft.AspNetCore.Mvc;

namespace TechCare_Prototipos.Controllers
{
    public class ComedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalle()
        {
            return View();
        }

        public IActionResult NuevaOrden()
        {
            return View();
        }

        public IActionResult Asignar()
        {
            return View();
        }
    }
}
