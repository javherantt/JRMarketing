using System;
using System.Collections.Generic;
using System.IO;
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
    public class PublicacionController : Controller
    {
        HttpClient client = new HttpClient();

        public PublicacionController()
        { }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var json = await client.GetStringAsync("https://localhost:44350/api/publicacion");
            var listPublicaciones = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Publicaciones>>>(json);
            var publicaciones = listPublicaciones.Data;
            return View(publicaciones);

        }  
        
        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Admin")
            {
                var json = await client.GetStringAsync("https://localhost:44350/api/publicacion");
                var listPublicaciones = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Publicaciones>>>(json);
                var publicaciones = listPublicaciones.Data;
                return View(publicaciones);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> PublicacionesRestaurante(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44350/api/publicacion");
                var listPublicaciones = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Publicaciones>>>(json);
                var publicaciones = listPublicaciones.Data.Where(e => e.IdRestaurantePubli == id);
                return View(publicaciones);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> IndexClient()
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Cliente")
            {
                int myId = (int)HttpContext.Session.GetInt32("id");
                var jsonRestau = await client.GetStringAsync("https://localhost:44350/api/restaurante");
                var listRestau = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(jsonRestau);
                var restaurante = listRestau.Data.First(e => e.IdUsuarioR == myId);
                var json = await client.GetStringAsync("https://localhost:44350/api/publicacion");
                var listPublicaciones = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Publicaciones>>>(json);
                var publicaciones = listPublicaciones.Data.Where(e => e.IdRestaurantePubli == restaurante.Id);
                return View(publicaciones);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        /*
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                var json = await client.GetStringAsync("https://localhost:44350/api/publicacion/" + id);
                var publicaciones = JsonConvert.DeserializeObject<ApiResponse<Publicaciones>>(json);
                return View(publicaciones.Data);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        */ 


        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("id") != null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublicacionesRequestDto publicacion)
        {
            if (HttpContext.Session.GetString("id") != null && HttpContext.Session.GetString("tipo") == "Cliente")
            {
                int myId = (int)HttpContext.Session.GetInt32("id");
                var userJson = await client.GetStringAsync("https://localhost:44350/api/restaurante");
                var listRestau = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Restaurantes>>>(userJson);
                var restuante = listRestau.Data.First(e => e.IdUsuarioR == myId);
                publicacion.IdRestaurantePubli = restuante.Id;
                string imagen = UploadImage(publicacion);
                publicacion.Foto = imagen;
                var json = await client.PostAsJsonAsync("https://localhost:44350/api/publicacion", publicacion);
                if (json.IsSuccessStatusCode)
                    return RedirectToAction("IndexClient");
                else
                    return View(publicacion);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        private string UploadImage(PublicacionesRequestDto imagen)
        {
            string fileName = null, filePath = null;    
            if (imagen.file != null)
            {
                string path = "C:/Users/Javier Hernández/Documents/Universidad/4° Cuatrimestre/Proyecto Integrador/myimages/";
                fileName = Guid.NewGuid().ToString() + "-" + imagen.file.FileName;
                filePath = Path.Combine(path, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen.file.CopyTo(fileStream);                  
                }
            }
            return fileName;
        }     

        public async Task<IActionResult> Update(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Cliente")
            {

                var json = await client.GetStringAsync("https://localhost:44350/api/publicacion/" + id);
                var publicacion = JsonConvert.DeserializeObject<ApiResponse<Publicaciones>>(json);
                return View(publicacion.Data);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Update(int id, Publicaciones publicacion)
        {
            if (HttpContext.Session.GetInt32("id") != null && HttpContext.Session.GetString("tipo") == "Cliente")
            {
                string imagen = UploadUpdate(publicacion);
                publicacion.Foto = imagen;
                client.BaseAddress = new Uri("https://localhost:44350/api/publicacion/");
                var putTask = client.PutAsJsonAsync<Publicaciones>("?id=" + id, publicacion);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("IndexClient");
                else
                    return View(Update(id));               
            }
            else
                return RedirectToAction("Index", "Home");
        }

        private string UploadUpdate(Publicaciones imagen)
        {
            string fileName = null, filePath = null;
            if (imagen.file != null)
            {
                string path = "C:/Users/Javier Hernández/Documents/Universidad/4° Cuatrimestre/Proyecto Integrador/myimages/";
                fileName = Guid.NewGuid().ToString() + "-" + imagen.file.FileName;
                filePath = Path.Combine(path, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen.file.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("id") != null)
            {
                using (client)
                {
                    client.BaseAddress = new Uri("https://localhost:44350/api/");
                    var deleteTask = client.DeleteAsync("publicacion/" + id.ToString());
                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("IndexClient");
                    else
                    {
                        ViewData["Message"] = "Error";
                        return RedirectToAction("IndexClient");
                    }
                }
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
