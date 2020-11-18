using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Domain.DTOs
{
    public class RestauranteResponseDto
    {
        public int Id { get; set; }
        public string NombreRestaurante { get; set; }
        public string DireccionR { get; set; }
        public string ColoniaR { get; set; }
        public string EstadoR { get; set; }
        public string CiudadR { get; set; }
        public string CoidgoPostalR { get; set; }
        public string DescripcionR { get; set; }
        public string Horario { get; set; }
        public string FotografiaR { get; set; }
        public int IdUsuarioR { get; set; }
    }

    public class RestauranteRequestDto
    {
        public string NombreRestaurante { get; set; }
        public string DireccionR { get; set; }
        public string ColoniaR { get; set; }
        public string EstadoR { get; set; }
        public string CiudadR { get; set; }
        public string CoidgoPostalR { get; set; }
        public string DescripcionR { get; set; }
        public string Horario { get; set; }
        public string FotografiaR { get; set; }
        public int IdUsuarioR { get; set; }
    }
}
