using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Cliente : BaseEntity
    {
        public string TipoContrato { get; set; }
        public DateTime? FinContrato { get; set; }

        public virtual Usuario IdNavigation { get; set; }
    }
}
