using Prototipos.DAL.Models;

namespace Prototipos.DAL.ViewModels
{
    public class ReservaNotificationViewModel
    {
        public Mesa MesaSeleccionada { get; set; }

        public string PersonaACargo { get; set; }

        public DateTime FechaReservada { get; set; }
    }
}
