using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Entities
{
    public class Foto
    {
        public IFormFile file { get; set; }
    }
}
