using JRMarketing.Gui.Models;
using JRMarketing.Gui.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JRMarketing.Gui.Controllers
{
    public class ConsultController : Controller
    {
        HttpClient httpClient = new HttpClient();
               
        public ConsultController()
        { }

        public IActionResult Index()
        {
            return View();
        }           
        
        [HttpGet]
        public async Task<IActionResult> Restaurantes(Consulta con)
        {
            if(con.EstadoR == "Estado") con.EstadoR = null;
            if(con.NombreRestaurante != null && con.EstadoR != null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante?NombreRestaurante=" + con.NombreRestaurante + "&estadoR=" + con.EstadoR);
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
                Consulta restaurantes = new Consulta();
                restaurantes.Restaurante = listRestaurantes.Data;
                return View(restaurantes);
            }
            else if(con.EstadoR != null && con.NombreRestaurante == null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante?estadoR=" + con.EstadoR);
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
                Consulta restaurantes = new Consulta();
                restaurantes.Restaurante = listRestaurantes.Data;
                return View(restaurantes);
            }
            else if(con.NombreRestaurante != null && con.EstadoR == null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante?NombreRestaurante=" + con.NombreRestaurante);
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
                Consulta restaurantes = new Consulta();
                restaurantes.Restaurante = listRestaurantes.Data;
                return View(restaurantes);
            }
            else
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/");
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
                Consulta restaurantes = new Consulta();
                restaurantes.Restaurante = listRestaurantes.Data;
                return View(restaurantes);
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Advertisements(int id)
        {
            var json = await httpClient.GetStringAsync("https://localhost:44350/api/publicacion");
            var listPubli = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Publicaciones>>>(json);
            var publicaciones = listPubli.Data.Where(e => e.IdRestaurantePubli == id);
            var jRest = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/" + id);
            var miRestau = JsonConvert.DeserializeObject<ApiResponse<Restaurantes>>(jRest);
            Consulta datos = new Consulta();
            datos.miRestaurante = miRestau.Data;
            datos.Publicaciones = publicaciones;
            return View(datos);
        }
        
    }
}
