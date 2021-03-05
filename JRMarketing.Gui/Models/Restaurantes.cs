using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRMarketing.Gui.Models
{
    public class Restaurantes : Foto
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

    public class RestaurantesRequestDto : Foto
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

        public string TelefonoRestaurante { get; set; }
    }
}
