using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Restaurante : BaseEntity
    {
        public Restaurante()
        {
            Publicacions = new HashSet<Publicacion>();
            RestauranteEtiqueta = new HashSet<RestauranteEtiquetum>();
        }

        public string NombreRestaurante { get; set; }
        public string DireccionR { get; set; }
        public string ColoniaR { get; set; }
        public string EstadoR { get; set; }
        public string CiudadR { get; set; }
        public string CoidgoPostalR { get; set; }
        public string DescripcionR { get; set; }
        public string Horario { get; set; }
        public string FotografiaR { get; set; }
        public int IdUsuarioR { get; set; }
        public string Telefono { get; set; }

        public virtual Usuario IdUsuarioRNavigation { get; set; }
        public virtual ICollection<Publicacion> Publicacions { get; set; }
        public virtual ICollection<RestauranteEtiquetum> RestauranteEtiqueta { get; set; }
    }
}
