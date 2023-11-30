using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipos.DAL.Models
{
    public class Usuario : BaseModel
    {
        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Role { get; set; }
        public string? Username { get; set; }
    }
}
