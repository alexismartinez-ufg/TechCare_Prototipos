using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.Models;
using Prototipos.DAL.ViewModels;

namespace TechCare_Prototipos.Controllers
{
    [Authorize(Roles = $"{RolesReferences.ResourceOwner},{RolesReferences.Administrador}")]
    public class AdministracionController : Controller
    {
        private readonly IMesasRepository mesasRepository;
        private readonly IReservasRepository reservasRepository;
        private readonly IZonasRepository zonasRepository;

        public AdministracionController(IMesasRepository _mesasRepository, IZonasRepository _zonasRepository, IReservasRepository _reservasRepository)
        {
            mesasRepository = _mesasRepository;
            zonasRepository = _zonasRepository;
            reservasRepository = _reservasRepository;
        }

        public async Task<IActionResult> Index(MesasViewModel model)
        {
            if(model.IdEditarMesa > 0)
            {
                model.EditarMesa = await mesasRepository.GetByIdAsync(model.IdEditarMesa);
            }

            model.Mesas = await mesasRepository.ListAsync();
            model.Zonas = await zonasRepository.ListAsync();

            return View(model);
        }

        public IActionResult Productos()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMesa(MesasViewModel model)
        {
            try
            {
                await mesasRepository.AddAsync(model.NuevaMesa);
                ViewBag.SuccessMessage = "Mesa agregada correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Eliminar(int idMesa)
        {
            try
            {
                var mesa = await mesasRepository.GetByIdAsync(idMesa);

                await reservasRepository.DeleteReservasByMesaId(mesa.Id);

                if (mesa != null)
                    await mesasRepository.DeleteAsync(mesa);
                ViewBag.SuccessMessage = "Mesa eliminada correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Editar(int idMesa)
        {   
            return RedirectToAction("Index", new MesasViewModel { IdEditarMesa = idMesa });
        }

        [HttpPost]
        public async Task<IActionResult> Editar(MesasViewModel model)
        {
            try
            {
                await mesasRepository.UpdateAsync(model.EditarMesa);
                ViewBag.SuccessMessage = "Mesa editada correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
