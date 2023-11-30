using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;

namespace TechCare_Prototipos.Controllers
{
    [Authorize(Roles = $"{RolesReferences.Cocinero},{RolesReferences.Gerente},{RolesReferences.ResourceOwner}")]
    public class CocinaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
