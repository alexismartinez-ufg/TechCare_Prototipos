using Prototipos.DAL.Models;

namespace Prototipos.DAL.ViewModels
{
    public class ComedorViewModel
    {
        public Cuenta Cuenta {  get; set; }

        public string Estado { get; set; }

        public Reserva Reserva { get; set; }

        public Mesa Mesa { get; set; }
    }
}
