using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JRMarketing.Domain.DTOs;
using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JRMarketing.Api.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteRepository _repository;
        private readonly IMapper _mapper;
        public RestauranteController(IRestauranteRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var restaurantes = await _repository.GetAll();
            var restaurantesDto = _mapper.Map<IEnumerable<Restaurante>, IEnumerable<RestauranteResponseDto>>(restaurantes);
            return Ok(restaurantesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var restaurante = await _repository.GetRestaurante(id);
            var restauranteDto = _mapper.Map<Restaurante, RestauranteResponseDto>(restaurante);
            return Ok(restauranteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequestDto restauranteDto)
        {
            var restaurante = _mapper.Map<Restaurante>(restauranteDto);
            await _repository.AddRestaurante(restaurante);
            var restauranteResponseDto = _mapper.Map<UsuarioResponseDto>(restaurante);
            return Ok(restauranteResponseDto);
        }
    }
}
