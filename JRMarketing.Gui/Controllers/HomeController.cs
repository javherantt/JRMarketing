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

namespace JRMarketing.Gui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public string url = "https://localhost:44350/api/usuario";

        HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsyinc(LoginModel login)
        {
            var json = await client.GetStringAsync(url);
            var usuarios = JsonConvert.DeserializeObject<List<UsuarioResponseDto>>(json);           
            var _usuario = usuarios.FirstOrDefault(e => e.NombreUsuario.Equals(login.NombreUsuario) && e.Contrasenia.Equals(login.Contrasenia));
            if (_usuario != null)
            {
                var myID = _usuario.Id;
            }                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
