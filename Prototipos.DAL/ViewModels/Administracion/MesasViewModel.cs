using Prototipos.DAL.Models;

namespace Prototipos.DAL.ViewModels
{
    public class MesasViewModel
    {
        public List<Mesa> Mesas { get; set; }

        public Mesa NuevaMesa { get; set; }
        public Mesa EditarMesa { get; set; }

        public List<Zona> Zonas { get; set; }
        public int IdEditarMesa { get; set; }
    }
}
