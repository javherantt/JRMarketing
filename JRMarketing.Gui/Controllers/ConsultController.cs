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
            Consulta restaurantes = new Consulta();
            if (con.NombreRestaurante != null && con.EstadoR != null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante?NombreRestaurante=" + con.NombreRestaurante + "&estadoR=" + con.EstadoR);
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
                var results = await buscarCategorias(listRestaurantes.Data, con.NombreRestaurante, con.EstadoR);
               
                restaurantes.Restaurante = results.Distinct();
                return View(restaurantes);
            }
            else if(con.EstadoR != null && con.NombreRestaurante == null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante?estadoR=" + con.EstadoR);
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);               
                restaurantes.Restaurante = listRestaurantes.Data;
                return View(restaurantes);
            }
            else if(con.NombreRestaurante != null && con.EstadoR == null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante?NombreRestaurante=" + con.NombreRestaurante);
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
                var results = await buscarCategorias(listRestaurantes.Data, con.NombreRestaurante, con.EstadoR);               
                restaurantes.Restaurante = results;
                return View(restaurantes);
            }
            else
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/");
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);       
                restaurantes.Restaurante = listRestaurantes.Data;
                return View(restaurantes);
            }
        }
        
        public async Task<IEnumerable<Restaurantes>> buscarCategorias(IEnumerable<Restaurantes> value, string etiquetaName, string estado)
        {
            List<Restaurantes> restaurantesAll = new List<Restaurantes>();
            foreach (var item in value)
            {
                restaurantesAll.Add(item);
            }
            var jsonRestuarantes = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante");
            var listRestaurantesAll = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(jsonRestuarantes);
            var jsonEtiquetas = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/namesEti");
            var listEtiquetas = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<EtiquetumName>>>(jsonEtiquetas);
            var searchedEti = listEtiquetas.Data.Where(e => e.NombreEtiqueta.StartsWith(etiquetaName));
            foreach (var item in listRestaurantesAll.Data)
            {
                foreach (var item2 in searchedEti)
                {
                    if(estado != null)
                    {
                        if (item.Id == item2.IdRestau && item.EstadoR == estado)
                            restaurantesAll.Add(item);
                    }
                    else
                    {
                        if (item.Id == item2.IdRestau)
                            restaurantesAll.Add(item);
                    }
                }
            }            
            return restaurantesAll;
        }
        [HttpGet]
        public async Task<IActionResult> Advertisements(int id)
        {
            var json = await httpClient.GetStringAsync("https://localhost:44350/api/publicacion");
            var listPubli = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Publicaciones>>>(json);
            var publicaciones = listPubli.Data.Where(e => e.IdRestaurantePubli == id);
            var jRest = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/" + id);
            var miRestau = JsonConvert.DeserializeObject<ApiResponse<Restaurantes>>(jRest);
            var jsonEtiquetas = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/namesEti");
            var etiquetasList = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<EtiquetumName>>>(jsonEtiquetas);
            Consulta datos = new Consulta();
            datos.miRestaurante = miRestau.Data;
            datos.Publicaciones = publicaciones;
            datos.Etiquetas = etiquetasList.Data.Where(e => e.IdRestau == id);
            return View(datos);
        }
        
    }
}
