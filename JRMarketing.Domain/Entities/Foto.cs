using System;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Foto
    {
        public int IdFoto { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public DateTime FechaSubida { get; set; }
        public int IdPublicacionFoto { get; set; }
        public DateTime? CreatedAtPhoto { get; set; }
        public DateTime? UpdatedAtPhoto { get; set; }

        public virtual Publicacion IdPublicacionFotoNavigation { get; set; }
    }
}
