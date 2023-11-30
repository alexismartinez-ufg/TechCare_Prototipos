using Microsoft.AspNetCore.Mvc;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.ViewModels;

namespace TechCare_Prototipos.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservasRepository reservasRepository;
        private readonly IMesasRepository mesasRepository;
        private readonly IMailNotificationService mailNotificationService;

        public ReservaController(IReservasRepository _reservasRepository, IMailNotificationService _mailNotificationService, IMesasRepository _mesasRepository)
        {
            reservasRepository = _reservasRepository;
            mailNotificationService = _mailNotificationService;
            mesasRepository = _mesasRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new ReservaViewModel
            {
                MesasDisponibles = await mesasRepository.ListAsync()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Reservar(ReservaViewModel model)
        {

            try
            {
                if (await reservasRepository.DoReserva(model))
                {
                    model.NotificationContent = new MailTemplates.ReservaCreationNotification()
                    {
                        Model = new ReservaNotificationViewModel
                        {
                            FechaReservada = model.FechaReserva,
                            MesaSeleccionada = model.MesaSeleccionada,
                            PersonaACargo = model.PersonaACargo
                        }
                    }.GenerateString();

                    await mailNotificationService.NotifyReserva(model);
                }

                return RedirectToAction("Success");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
