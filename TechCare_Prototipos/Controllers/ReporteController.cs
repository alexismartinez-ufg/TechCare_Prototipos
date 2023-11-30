using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;

namespace TechCare_Prototipos.Controllers
{
    [Authorize(Roles = $"{RolesReferences.Gerente},{RolesReferences.ResourceOwner}")]
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
