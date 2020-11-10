#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class TelefonoUsuario
    {
        public int IdTelefonoUser { get; set; }
        public string NumeroUsuario { get; set; }

        public virtual Usuario IdTelefonoUserNavigation { get; set; }
    }
}
