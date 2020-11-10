using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Domain.DTOs
{
    public class EtiquetumRequestDto
    {    
        public string NombreEtiqueta { get; set; }
    }

    public class EtiquetumResponseDto
    {
        public int IdEtiqueta { get; set; }
        public string NombreEtiqueta { get; set; }
    }
}
