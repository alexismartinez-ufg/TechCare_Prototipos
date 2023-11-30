using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipos.DAL.Models
{
    public class Reserva : BaseModel
    {
        [ForeignKey("Mesa")]
        public int? IdMesa { get; set; }
        public virtual Mesa? Mesa { get; set; }
        public string? PersonaACargo { get; set; }
        public string? Contacto { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaReserva { get; set; }
        public string? EstadoReserva { get; set; }
    }
}
