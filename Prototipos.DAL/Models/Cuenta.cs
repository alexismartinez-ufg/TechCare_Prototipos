using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipos.DAL.Models
{
    public class Cuenta : BaseModel
    {
        [ForeignKey("Mesa")]
        public int? IdMesa { get; set; }

        public Mesa? Mesa { get; set; }

        [ForeignKey("Mesero")]
        public int? IdMesero { get; set; }

        public Usuario? Mesero { get; set;}

        public string? ComensalACargo { get; set; }

        public int? CantidadPersonas { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string? EstadoCuenta { get; set; }

        [ForeignKey("CuentaPadre")]
        public int? IdCuentaPadre { get; set; }
                
        public Cuenta? CuentaPadre { get; set; }

        public virtual ICollection<Cuenta>? CuentasHijas { get; set; }
    }
}
