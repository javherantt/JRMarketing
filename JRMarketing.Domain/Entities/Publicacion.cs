using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Publicacion : BaseEntity
    {
        public Publicacion()
        {
            Fotos = new HashSet<Foto>();
        }

        public string DescripcionP { get; set; }
        public int IdRestaurantePubli { get; set; }

        public virtual Restaurante IdRestaurantePubliNavigation { get; set; }
        public virtual ICollection<Foto> Fotos { get; set; }
    }
}
