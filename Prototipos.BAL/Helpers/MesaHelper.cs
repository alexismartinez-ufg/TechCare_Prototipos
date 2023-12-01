using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipos.BAL.Helpers
{
    public static class MesaStateReferences
    {
        public const string Asignada = "Asignada";
        public const string Libre = "Libre";
        public const string Reservada = "Reservada";
    }

    public static class MesaTextStyle
    {
        public static string GetTextColor(string estado)
        {
            return TextColors[estado] ?? string.Empty;
        }

        public static Dictionary<string, string> TextColors = new Dictionary<string, string>
        {
            {MesaStateReferences.Libre, "text-success" },
            {MesaStateReferences.Reservada, "text-warning" },
            {MesaStateReferences.Asignada, "text-danger" },
        };
    }
}
