using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRMarketing.Gui.Models
{
    public class Consulta:PageModel
    {
        public string NombreRestaurante { get; set; }
        public string EstadoR { get; set; }
    }
}
