using JRMarketing.Gui.Controllers;
using JRMarketing.Gui.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace JRMarketing.Testing
{
    public class Tests
    {
        [Test]
        public async Task AgregarUsuario()
        {
            UsuarioController controller = new UsuarioController();
            Usuarios user = new Usuarios()
            {
                NombreUsuario = "MyUserName",
                Contrasenia = "Password",
                Nombre = "MyName",
                Apellidos = "MyLasrName",
                Direccion = "MyAddres",
                Colonia = "MyColony",
                Estado = "MyState",
                Ciudad = "MyCity",
                CoidgoPostal = "12345",
                Correo = "MYEmail",
                FechaNacimiento = DateTime.Now,
                Tipo = "Admin"
            };
            var respuesta = await controller.Create(user) as ViewResult;
            Assert.IsNotNull(respuesta.Model);
        }

        [Test]
        public async Task ActualizarUsuario()
        {
            var controller = new UsuarioController();
            var usuario = new Usuarios()
            {
                NombreUsuario = "MyUserName",
                Contrasenia = "Password",
                Nombre = "MyName",
                Apellidos = "MyLasrName",
                Direccion = "MyAddres",
                Colonia = "MyColony",
                Estado = "MyState",
                Ciudad = "MyCity",
                CoidgoPostal = "12345",
                Correo = "MYEmail",
                FechaNacimiento = DateTime.Now,
                Tipo = "Admin"
            };

            ViewResult result = controller.Update(2, usuario) as ViewResult;
            await Task.Delay(10);
            Assert.IsNotNull(result.ViewData["Message"]);
        }



        [Test]
        public void Buscar()
        {
            bool resp = false;
            var controller = new UsuarioController();
            var usuario = controller.Detail(3);
            if (usuario != null)
                resp = true;
            Assert.IsTrue(resp);
        }


        [Test]
        public void Eliminar()
        {
            var controller = new UsuarioController();
            Assert.IsNotNull(controller.Delete(3));
        }

    }
}