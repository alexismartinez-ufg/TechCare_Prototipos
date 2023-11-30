using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;

namespace TechCare_Prototipos.Controllers
{
    [Authorize(Roles = $"{RolesReferences.Mesero},{RolesReferences.Gerente},{RolesReferences.ResourceOwner}")]
    public class ComedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalle(bool? Success)
        {
            if (Success.HasValue && Success.Value)
            {
                ViewBag.Success = true;
            }

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
