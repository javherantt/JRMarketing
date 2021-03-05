using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JRMarketing.Gui.Models;
using JRMarketing.Gui.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult> Restaurantes()
        {
            var json = await httpClient.GetStringAsync("https://localhost:44350/api/restaurante");
            var listRestaurantes = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(json);
            var restaurantes = listRestaurantes.Data;
            return View(restaurantes);
        }
    }
}
