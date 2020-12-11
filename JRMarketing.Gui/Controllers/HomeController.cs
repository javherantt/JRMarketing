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
using Microsoft.AspNetCore.Http;
using JRMarketing.Gui.Responses;

namespace JRMarketing.Gui.Controllers
{
    public class HomeController : Controller
    {


        
        HttpClient client = new HttpClient();
        public string url = "https://localhost:44350/api/usuario";
 

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(LoginModel login)
        {
            string route;
            var json = await client.GetStringAsync("https://localhost:44350/api/usuario/");
            var Usuarios = JsonConvert.DeserializeObject<ApiResponse<List<Usuarios>>>(json);
            var _Usuario = Usuarios.Data.FirstOrDefault(e => e.NombreUsuario.Equals(login.NombreUsuario) && e.Contrasenia.Equals(login.Contrasenia));
            if (_Usuario != null && _Usuario.Tipo == "Admin")
            {
                HttpContext.Session.SetInt32("id", _Usuario.Id);
                HttpContext.Session.SetString("tipo", _Usuario.Tipo);
                route = "IndexAdministracion";
            }
            else if (_Usuario != null && _Usuario.Tipo == "Cliente")
            {
                HttpContext.Session.SetInt32("id", _Usuario.Id);
                HttpContext.Session.SetString("tipo", _Usuario.Tipo);
                route = "IndexCliente";
            }
            else
                route = "Index";

            return RedirectToAction(route);
        }

        public IActionResult IndexAdministracion()
        {
            if (HttpContext.Session.GetString("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
                return View();            
            else            
                return RedirectToAction("Index");            
        }

        public IActionResult IndexCliente()
        {
            if (HttpContext.Session.GetString("id") != null && HttpContext.Session.GetString("tipo") == "Cliente")
                return View();            
            else            
                return RedirectToAction("Index");            
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("tipo");
            return RedirectToAction("Index");
        }

 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
