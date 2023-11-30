using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;

namespace TechCare_Prototipos.Controllers
{
    [Authorize(Roles = $"{RolesReferences.Cajero},{RolesReferences.Gerente},{RolesReferences.ResourceOwner}")]
    public class CajaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Finalizar()
        {
            return View();
        }

        public IActionResult Detalle()
        {
            return View();
        }

        public IActionResult Ticket()
        {
            return View();
        }
    }
}
