using Prototipos.DAL.Models;

namespace Prototipos.DAL.ViewModels
{
    public class CrearCuentaViewModel
    {
        public Reserva Reserva { get; set; }

        public Mesa Mesa { get; set; }
        public string PersonaACargo { get; set; }

        public Usuario Mesero { get; set; } 

        public int CantidadPersonas { get; set; }
        public DateTime FechaDeAsignacion { get; set; } = DateTime.Now;
    }
}
