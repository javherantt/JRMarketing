using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JRMarketing.Domain.DTOs;
using JRMarketing.Gui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using JRMarketing.Api.Responses;
using System.Net.Http.Headers;

namespace JRMarketing.Gui.Controllers
{
    public class UsuarioController : Controller
    {      

        HttpClient client = new HttpClient();
        string url = "https://localhost:44350/";

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Usuarios> usuarios = null;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44350/api/");
                var responseTask = client.GetAsync("usuario");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Usuarios>>();
                    readTask.Wait();
                    usuarios = readTask.Result;
                }
                else
                {
                    usuarios = Enumerable.Empty<Usuarios>();
                    ModelState.AddModelError(string.Empty, "Error en el servidor");
                }
               
            }
            return View(usuarios);
        }

        /*
        public async  Task<IActionResult> IndexAsync()
        {
            if(HttpContext.Session.GetString("id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44350/api/usuario/");
                var usuarios = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(json);
                return View(usuarios.Data);
            }
            else
            {
                return RedirectToAction("Index", "Inicio");
            }
        }

        */

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            if(HttpContext.Session.Get("id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44350/api/usuario/" + id);
                var usuario = JsonConvert.DeserializeObject<ApiResponse<UsuarioResponseDto>>(json);
                return View(usuario.Data);
            }
            else
            {
                return RedirectToAction("Index", "Inicio");
            }
        }

        [HttpPost]
        public IActionResult Update(int id, UsuarioRequestDto usuarioDto)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44350/api/usuario/");
            var putTask = httpClient.PutAsJsonAsync("?id=" + id, usuarioDto);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(usuarioDto);
        }
    }
}
