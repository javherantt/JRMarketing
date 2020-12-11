using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JRMarketing.Gui.Models;
using JRMarketing.Gui.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JRMarketing.Gui.Controllers
{
    public class RestauranteController : Controller
    {
        HttpClient httpClient = new HttpClient();

        public RestauranteController()
        { }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
            {                
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante");
                var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
                var restaurantes = listRestaurantes.Data;
                return View(restaurantes);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/" + id);
                var restaurante = JsonConvert.DeserializeObject<ApiResponse<Restaurantes>>(json);
                return View(restaurante.Data);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public async Task<int> RestauranteIdUser(int id)
        {
            var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante");
            var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
            var restaurantes = listRestaurantes.Data.Where(e => e.IdUsuarioR == id);
            var ide = restaurantes.fi
        }

        public ViewResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(RestaurantesRequestDto restaurante)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                var json = await httpClient.PostAsJsonAsync("https://localhost:44350/api/restaurante/", restaurante);
                if (json.IsSuccessStatusCode)
                {
                    if (HttpContext.Session.GetString("tipo") == "Admin")
                        return RedirectToAction("IndexAdministracion", "Home");
                    else
                        return RedirectToAction("IndexCliente", "Home");
                }
                else
                    return View(restaurante);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Update(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante/" + id);
                var restaurante = JsonConvert.DeserializeObject<ApiResponse<Restaurantes>>(json);
                return View(restaurante.Data);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(int id, Restaurantes restaurante)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                httpClient.BaseAddress = new Uri("https://localhost:44350/api/restaurante/");
                var putTask = httpClient.PutAsJsonAsync<Restaurantes>("?id" + id, restaurante);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    if (HttpContext.Session.GetString("tipo") == "Admin")
                        return RedirectToAction("IndexAdministracion", "Home");
                    else
                        return RedirectToAction("IndexCliente", "Home");
                }
                else ViewData["Message"] = "Error";

                return View(restaurante);
            }
            else
                return RedirectToAction("Index", "Home");
        }


    }
}
;