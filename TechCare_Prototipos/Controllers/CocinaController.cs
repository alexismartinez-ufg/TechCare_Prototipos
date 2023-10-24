using Microsoft.AspNetCore.Mvc;

namespace TechCare_Prototipos.Controllers
{
    public class CocinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
