using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using JRMarketing.Api.Responses;
using JRMarketing.Domain.DTOs;
using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Domain.QueryFilters;
using Microsoft.AspNetCore.Mvc;

namespace JRMarketing.Api.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteServices _service;
        private readonly IMapper _mapper;
        public RestauranteController(IRestauranteServices services, IMapper mapper)
        {
            this._service = services;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<RestauranteResponseDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<RestauranteResponseDto>>))]
        public IActionResult Get([FromQuery]RestauranteQueryFilter filter)
        {
            var restaurantes = _service.GetRestaurantes(filter);
            var restaurantesDto = _mapper.Map<IEnumerable<Restaurante>, IEnumerable<RestauranteResponseDto>>(restaurantes);
            var response = new ApiResponse<IEnumerable<RestauranteResponseDto>>(restaurantesDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var restaurante = await _service.GetRestaurante(id);
            var restauranteDto = _mapper.Map<Restaurante, RestauranteResponseDto>(restaurante);
            var response = new ApiResponse<RestauranteResponseDto>(restauranteDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RestauranteRequestDto restauranteDto, [FromForm] Foto imagen)
        {
            if (imagen.file.Length > 0)
            {
                string path = "C:/Users/Javier Hernández/Documents/Universidad/4° Cuatrimestre/Proyecto Integrador/Images/";
                using (FileStream fileStream = System.IO.File.Create(path + imagen.file.FileName))
                {
                    imagen.file.CopyTo(fileStream);
                    fileStream.Flush();                    
                }
            }         

            var restaurante = _mapper.Map<RestauranteRequestDto, Restaurante>(restauranteDto);   
            await _service.AddRestaurante(restaurante);
            var restauranteResponseDto = _mapper.Map<Restaurante, RestauranteResponseDto>(restaurante);
            var response = new ApiResponse<RestauranteResponseDto>(restauranteResponseDto);
            
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRestaurante(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, RestauranteRequestDto2 restuaranteDto)
        {
            var restuarante = _mapper.Map<Restaurante>(restuaranteDto);
            restuarante.Id = id;
            restuarante.UpdatedAt = DateTime.Now;
            restuarante.CreatedAt = DateTime.Now;

            await _service.UpdateRestaurante(restuarante);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }


    }
    
}
