using System;
using System.Collections.Generic;

#nullable disable

namespace JRMarketing.Domain.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            Restaurantes = new HashSet<Restaurante>();
        }

        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string CoidgoPostal { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Tipo { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual TelefonoUsuario TelefonoUsuario { get; set; }
        public virtual ICollection<Restaurante> Restaurantes { get; set; }
    }
}
