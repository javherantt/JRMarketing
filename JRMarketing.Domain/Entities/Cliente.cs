using System;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string TipoContrato { get; set; }
        public DateTime? FinContrato { get; set; }

        public virtual Usuario IdClienteNavigation { get; set; }
    }
}
