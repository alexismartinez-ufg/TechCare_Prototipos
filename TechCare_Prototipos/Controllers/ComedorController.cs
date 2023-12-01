using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace TechCare_Prototipos.Controllers
{
    [Authorize(Roles = $"{RolesReferences.Mesero},{RolesReferences.Gerente},{RolesReferences.ResourceOwner}")]
    public class ComedorController : Controller
    {
        private readonly IMesasRepository mesasRepository;
        private readonly ICuentasRepository cuentasRepository;
        private readonly IUsuariosRepository usuariosRepository;

        public ComedorController(IMesasRepository _mesasRepository, ICuentasRepository _cuentasRepository, IUsuariosRepository _usuariosRepository)
        {
            mesasRepository = _mesasRepository;
            cuentasRepository = _cuentasRepository;
            usuariosRepository = _usuariosRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await mesasRepository.GetComedor());
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

        public async Task<IActionResult> Asignar(int idMesa)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (idMesa >0)
                return View(new CrearCuentaViewModel
                {   
                    Mesa = await mesasRepository.GetByIdAsync(idMesa),
                    Reserva = await mesasRepository.GetReservaInfo(idMesa),
                    Mesero = await usuariosRepository.GetByIdAsync(int.Parse(userId))
                });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Asignar(CrearCuentaViewModel cuenta)
        {
            try
            {
                await cuentasRepository.CreateCuentaByViewModel(cuenta);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
