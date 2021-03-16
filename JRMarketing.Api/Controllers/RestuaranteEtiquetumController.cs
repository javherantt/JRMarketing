using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JRMarketing.Api.Responses;
using JRMarketing.Domain.DTOs;
using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JRMarketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestuaranteEtiquetumController : ControllerBase
    {
        
        private readonly IRestauranteEtiquetumService _service;
        private readonly IMapper _mapper;

        public RestuaranteEtiquetumController(IRestauranteEtiquetumService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var restaurantEtiquetum = _service.Get();
            var restauranteEtiDto = _mapper.Map<IEnumerable<RestauranteEtiquetum>, IEnumerable<RestauranteEtiquetumDto>>(restaurantEtiquetum);
            var response = new ApiResponse<IEnumerable<RestauranteEtiquetumDto>>(restauranteEtiDto);
            return Ok(response);
        }

        [HttpGet("{rest:int}/{eti:int}")]
        public IActionResult GetRestaurantEtiquetum(int rest, int eti)
        {
            var restaurantEtiquetum = _service.GetEtiquetum(rest, eti);
            var restauranteEtiDto = _mapper.Map<RestauranteEtiquetum, RestauranteEtiquetumDto>(restaurantEtiquetum);
            var response = new ApiResponse<RestauranteEtiquetumDto>(restauranteEtiDto);
            return Ok(response);
        }

        [HttpGet("{rest:int}")]
        public IActionResult GetRestaurant(int rest)
        {
            var restuarantEtiquetums = _service.GetRestauranteEtiqueta(rest);
            var restauranteEtiquetumsDto = _mapper.Map<IEnumerable<RestauranteEtiquetum>, IEnumerable<RestauranteEtiquetumDto>>(restuarantEtiquetums);
            var response = new ApiResponse<IEnumerable<RestauranteEtiquetumDto>>(restauranteEtiquetumsDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RestauranteEtiquetumDto restauranteEtiquetumDto)
        {
            var restauranteEtiquetum = _mapper.Map<RestauranteEtiquetumDto, RestauranteEtiquetum>(restauranteEtiquetumDto);
            await _service.AddRestuaranteEtiquetum(restauranteEtiquetum);
            var restauranteEtiResponse = _mapper.Map<RestauranteEtiquetum, RestauranteEtiquetumDto>(restauranteEtiquetum);
            var response = new ApiResponse<RestauranteEtiquetumDto>(restauranteEtiResponse);
            return Ok(response);
        }

        [HttpDelete("{rest:int}/{etiq:int}")]
        public IActionResult Delete(int rest, int etiq)
        {
            _service.DeleteRestauranteEtiquetum(rest, etiq);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int restuarant, int etiquetum, RestauranteEtiquetumDto restauranteEtiquetumDto)
        {
            var restuaranteEtiquetum = _mapper.Map<RestauranteEtiquetum>(restauranteEtiquetumDto);
            await _service.UpdateRestauranteEtiqeutum(restuaranteEtiquetum);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }
        
    }
}
