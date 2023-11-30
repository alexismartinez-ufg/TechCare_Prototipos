using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipos.DAL.Models
{
    public class Mesa : BaseModel
    {
        public string? NombreMesa { get; set; }
        
        public int? Personas { get; set; }
        [ForeignKey("Zona")]
        
        public int? IdZona { get; set; }
        
        public Zona? Zona { get; set; }
    }
}
