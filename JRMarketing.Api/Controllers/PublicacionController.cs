using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JRMarketing.Api.Responses;
using JRMarketing.Domain.DTOs;
using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JRMarketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionController : Controller
    {
        private readonly IPublicacionService _service;
        private readonly IMapper _mapper;

        public PublicacionController(IPublicacionService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var publicaciones = _service.GetPublicacions();
            var publicacionesDto = _mapper.Map<IEnumerable<Publicacion>, IEnumerable<PublicacionResponseDto>>(publicaciones);
            var response = new ApiResponse<IEnumerable<PublicacionResponseDto>>(publicacionesDto);
            return Ok(response);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var publicacion = await _service.GetPublicacion(id);
            var publicacionDto = _mapper.Map<Publicacion, PublicacionResponseDto>(publicacion);
            var response = new ApiResponse<PublicacionResponseDto>(publicacionDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PublicacionRequestDto publicacionDto, [FromForm] Foto objectFile)
        {
            if (objectFile.file.Length > 0)
            {
                string path = "C:/Users/Javier Hernández/Documents/Universidad/4° Cuatrimestre/Proyecto Integrador/Images/";
                using (FileStream fileStream = System.IO.File.Create(path + objectFile.file.FileName))
                {
                    objectFile.file.CopyTo(fileStream);
                    fileStream.Flush();
                    publicacionDto.Foto = path + objectFile.file.FileName;

                }
            }
            var publicacion = _mapper.Map<PublicacionRequestDto, Publicacion>(publicacionDto);
            await _service.AddPublicacion(publicacion);
            var publicacionResponseDto = _mapper.Map<Publicacion, PublicacionResponseDto>(publicacion);
            var response = new ApiResponse<PublicacionResponseDto>(publicacionResponseDto);
            return Ok(response);

        }
       

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePublicacion(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PublicacionRequestDto publicacionDtio)
        {
            var publicacion = _mapper.Map<Publicacion>(publicacionDtio);
            publicacion.Id = id;
            publicacion.UpdatedAt = DateTime.Now;
            await _service.UpdatePublicacion(publicacion);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }       


    }
}
