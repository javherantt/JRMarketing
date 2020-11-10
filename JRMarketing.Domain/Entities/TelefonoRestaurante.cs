#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class TelefonoRestaurante
    {
        public int IdTelefonoRestau { get; set; }
        public string NumeroRestaurante { get; set; }

        public virtual Restaurante IdTelefonoRestauNavigation { get; set; }
    }
}
