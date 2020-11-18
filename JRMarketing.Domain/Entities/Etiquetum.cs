using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Etiquetum : BaseEntity
    {
        public Etiquetum()
        {
            RestauranteEtiqueta = new HashSet<RestauranteEtiquetum>();
        }

        public string NombreEtiqueta { get; set; }  

        public virtual ICollection<RestauranteEtiquetum> RestauranteEtiqueta { get; set; }
    }
}
