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
    public class EtiquetumController : Controller
    {
        HttpClient httpClient = new HttpClient();

        public EtiquetumController()
        { }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/etiquetum");
                var listEtiquetas = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Etiquetum>>>(json);
                return View(listEtiquetas.Data);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Etiquetum etiquetum)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
            {
                var postTask = await httpClient.PostAsJsonAsync("https://localhost:44350/api/etiquetum", etiquetum);
                if (postTask.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return this.BadRequest();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
            {
                var json = await httpClient.GetStringAsync("https://localhost:44350/api/etiquetum/" + id);
                var etiqueta = JsonConvert.DeserializeObject<ApiResponse<Etiquetum>>(json);
                return View(etiqueta.Data);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(Etiquetum etiquetum)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
            {
                httpClient.BaseAddress = new Uri("https://localhost:44350/api/etiquetum/");
                var putTask = httpClient.PutAsJsonAsync<Etiquetum>("?id=" + etiquetum.Id, etiquetum);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return this.BadRequest();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
            {
                var deleteTask = httpClient.DeleteAsync("https://localhost:44350/api/etiquetum/" + id.ToString());
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else
                    return this.BadRequest();
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
