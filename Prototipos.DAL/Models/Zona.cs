namespace Prototipos.DAL.Models
{
    public class Zona : BaseModel
    {
        public string? NombreZona { get; set; }
        public virtual ICollection<Mesa>? Mesas { get; set; }
    }
}
