﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;

namespace TechCare_Prototipos.Controllers
{
    [Authorize(Roles = $"{RolesReferences.Administrador},{RolesReferences.ResourceOwner}")]
    public class AdministracionController : Controller
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
