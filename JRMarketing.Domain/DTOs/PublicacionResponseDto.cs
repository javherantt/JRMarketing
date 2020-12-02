using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Domain.DTOs
{
    public class PublicacionResponseDto
    {
        public int Id { get; set; }
        public string DescripcionP { get; set; }
        public int IdRestaurantePubli { get; set; }
    }

    public class PublicacionRequestDto
    {
        public string DescripcionP { get; set; }
        public int IdRestaurantePubli { get; set; }
    }
}
