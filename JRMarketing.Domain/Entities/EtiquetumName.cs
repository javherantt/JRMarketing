using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JRMarketing.Domain.Entities
{    
    public class EtiquetumName
    {        
        public string NombreEtiqueta { get; set; }
        public int IdRestau { get; set; }
        public int IdEtiqueta { get; set; }
    }
}
