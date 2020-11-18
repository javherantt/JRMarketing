using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class RestauranteEtiquetum : BaseEntity
    {
        public int IdRestauranteEtiq { get; set; }
        public int IdEtiquetaRestau { get; set; }

        public virtual Etiquetum IdEtiquetaRestauNavigation { get; set; }
        public virtual Restaurante IdRestauranteEtiqNavigation { get; set; }
    }
}
