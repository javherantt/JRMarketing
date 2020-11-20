using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JRMarketing.Domain.DTOs;
using JRMarketing.Gui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace JRMarketing.Gui.Controllers
{
    public class UsuarioController : Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://localhost:44350/api/usuario";

        public async  Task<IActionResult> Index()
        {
            return View();
        }
    }
}
