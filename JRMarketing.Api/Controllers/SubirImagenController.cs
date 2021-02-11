using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JRMarketing.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JRMarketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubirImagenController : ControllerBase
    {
   
        [HttpPost]
        public string Post([FromForm] FileUpload objectFile)
        {
            try
            {
                if (objectFile.file.Length > 0)
                {
                    string path = "C:/Users/Javier Hernández/Documents/Universidad/4° Cuatrimestre/Proyecto Integrador/Images/";
                    using (FileStream fileStream = System.IO.File.Create(path + objectFile.file.FileName))
                    {
                        objectFile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Imagen subida";
                    }
                }
                else
                {
                    return "Imagen no subido";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
