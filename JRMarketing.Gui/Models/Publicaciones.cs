using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRMarketing.Gui.Models
{
    public class Publicaciones : Foto
    {
        public int Id { get; set; }
        public string DescripcionP { get; set; }
        public int IdRestaurantePubli { get; set; }
        public string Foto { get; set; }
    }

    public class PublicacionesRequestDto : Foto
    {  
        public string DescripcionP { get; set; }
        public int IdRestaurantePubli { get; set; }
        public string Foto { get; set; }

    }
}
