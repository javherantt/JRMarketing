using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JRMarketing.Gui.Models;
using System.Net.Http;
using Newtonsoft.Json;
using JRMarketing.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using JRMarketing.Api.Responses;

namespace JRMarketing.Gui.Controllers
{
    public class HomeController : Controller
    {
        
        HttpClient client = new HttpClient();
        public string url = "https://localhost:44350/api/usuario";       

        public HomeController()
        { }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsyinc(LoginModel login)
        {
            var json = await client.GetStringAsync("https://localhost:44350/api/usuario");
            var usuarios = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(json);
            var _usuario = usuarios.Data.FirstOrDefault(e => e.NombreUsuario.Equals(login.NombreUsuario) && e.Contrasenia.Equals(login.Contrasenia));
            if (_usuario != null)
            {
                HttpContext.Session.SetString("id", _usuario.Id.ToString());
                return RedirectToAction("Admin");

            }else if(_usuario == null)
            {
                login.status = false;
                return View();
            }

            return View();
        }
        
        public IActionResult Administracion()
        {
            if (HttpContext.Session.GetString("id") != null)
                return View();
            else
                return RedirectToAction("Index");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index");
        }
    }
}
