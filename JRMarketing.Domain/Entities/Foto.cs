using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Foto : BaseEntity
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public DateTime FechaSubida { get; set; }
        public int IdPublicacionFoto { get; set; } 

        //public virtual Publicacion IdPublicacionFotoNavigation { get; set; }
    }
}
