﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JRMarketing.Gui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using JRMarketing.Gui.Responses;

namespace JRMarketing.Gui.Controllers
{
    public class UsuarioController : Controller
    {
        
        HttpClient client = new HttpClient();

        public UsuarioController()
        { }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.Get("id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44350/api/usuario");
                var ListProductos = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Usuarios>>>(Json);
                var clientes = ListProductos.Data.Where(e => e.Tipo == "Cliente");
                return View(clientes);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> IndexAdmin()
        {
            if (HttpContext.Session.Get("id") != null)
            {
                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("https://localhost:44350/api/usuario");
                var ListProductos = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Usuarios>>>(Json);
                var clientes = ListProductos.Data.Where(e => e.Tipo == "Admin");
                return View(clientes);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            if(HttpContext.Session.Get("id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44350/api/usuario/" + id);
                var usuario = JsonConvert.DeserializeObject<ApiResponse<Usuarios>>(json);
                return View(usuario.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("id") != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Usuarios usuario)
        {           
            var httpClient = new HttpClient();
            var Json = await httpClient.PostAsJsonAsync("https://localhost:44350/api/usuario/", usuario);
            if (Json.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public async Task<IActionResult> Update(int id)
        {
            if (HttpContext.Session.GetString("id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44350/api/usuario/" + id);
                var _Cliente = JsonConvert.DeserializeObject<ApiResponse<Usuarios>>(json);
                return View(_Cliente.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Update(int Id, Usuarios usuario)
        {

            var httpClient = new HttpClient();       
            httpClient.BaseAddress = new Uri("https://localhost:44350/api/usuario/");
            var putTask = httpClient.PutAsJsonAsync<Usuarios>("?id=" + Id, usuario);
            putTask.Wait();

            var result = putTask.Result;
            if (!result.IsSuccessStatusCode)
            {
                ViewData["Message"] = "Error";
            }
            else if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44350/api/");
                var deleteTask = client.DeleteAsync("usuario/" + id.ToString());
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }                        
            }
            return RedirectToAction("Index");
        }
        
    }
}
