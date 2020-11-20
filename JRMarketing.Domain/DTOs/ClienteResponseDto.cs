using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Domain.DTOs
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string TipoContrato { get; set; }
        public DateTime? FinContrato { get; set; }
    }

    public class ClienteRequestDto
    {
        public string TipoContrato { get; set; }
        public DateTime? FinContraro { get; set; }
    }
}
