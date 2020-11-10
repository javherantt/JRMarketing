using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Etiquetum
    {
        public Etiquetum()
        {
            RestauranteEtiqueta = new HashSet<RestauranteEtiquetum>();
        }

        public int IdEtiqueta { get; set; }
        public string NombreEtiqueta { get; set; }

        public virtual ICollection<RestauranteEtiquetum> RestauranteEtiqueta { get; set; }
    }
}
