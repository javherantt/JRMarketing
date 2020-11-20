using System;
using System.Collections.Generic;
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
    public class RestauranteController : Controller
    {
        private readonly IRestauranteServices _service;
        private readonly IMapper _mapper;
        public RestauranteController(IRestauranteServices services, IMapper mapper)
        {
            this._service = services;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var restaurantes = _service.GetRestaurantes();
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
        public async Task<IActionResult> Post(RestauranteRequestDto restauranteDto)
        {
            var restaurante = _mapper.Map<RestauranteRequestDto, Restaurante>(restauranteDto);
            await _service.AddRestaurante(restaurante);
            var restauranteResponseDto = _mapper.Map<Restaurante, RestauranteResponseDto>(restaurante);
            var response = new ApiResponse<RestauranteResponseDto>(restauranteResponseDto);
            return Ok(response);
        }
    }
    
}
