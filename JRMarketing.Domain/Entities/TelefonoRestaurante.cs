using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class TelefonoRestaurante : BaseEntity
    {
        public string NumeroRestaurante { get; set; }

        public virtual Restaurante IdNavigation { get; set; }
    }
}
