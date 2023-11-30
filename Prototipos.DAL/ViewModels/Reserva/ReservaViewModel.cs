using Prototipos.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Prototipos.DAL.ViewModels
{
    public class ReservaViewModel
    {
        public int? IdMesa { get; set; } = null;
        public Mesa MesaSeleccionada { get; set; }
        public string PersonaACargo { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaReserva { get; set; } = DateTime.Now;
        public List<Mesa> MesasDisponibles { get; set; }
        public string NotificationContent { get; set; }
    }
}
