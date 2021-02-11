using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Domain.QueryFilters
{
    public class RestauranteQueryFilter
    {
        public string NombreRestaurante { get; set; }
        public string EstadoR { get; set; }
        public ICollection<RestauranteEtiquetum> RestauranteEtiqueta { get; set; }
    }
}
