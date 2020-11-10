#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class RestauranteEtiquetum
    {
        public int IdRestauranteEtiq { get; set; }
        public int IdEtiquetaRestau { get; set; }

        public virtual Etiquetum IdEtiquetaRestauNavigation { get; set; }
        public virtual Restaurante IdRestauranteEtiqNavigation { get; set; }
    }
}
