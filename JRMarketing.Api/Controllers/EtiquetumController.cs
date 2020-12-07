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
    [ApiController]
    public class EtiquetumController : ControllerBase
    {
        private readonly IEtiquetumService _service;
        private readonly IMapper _mapper;

        public EtiquetumController(IEtiquetumService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var etiquetas = _service.GetEtiquetas();
            var etiquetasDto = _mapper.Map<IEnumerable<Etiquetum>, IEnumerable<EtiquetumResponseDto>>(etiquetas);
            var response = new ApiResponse<IEnumerable<EtiquetumResponseDto>>(etiquetasDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var etiqueta = await _service.GetEtiqueta(id);
            var etiquetasDto = _mapper.Map<Etiquetum, EtiquetumResponseDto>(etiqueta);
            var response = new ApiResponse<EtiquetumResponseDto>(etiquetasDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EtiquetumRequestDto etiquetumDto)
        {
            var etiqueta = _mapper.Map<EtiquetumRequestDto, Etiquetum>(etiquetumDto);
            await _service.AddEtiqueta(etiqueta);
            var etiquetaResponseDto = _mapper.Map<Etiquetum, EtiquetumResponseDto>(etiqueta);
            var response = new ApiResponse<EtiquetumResponseDto>(etiquetaResponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteEtiqueta(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, EtiquetumRequestDto etiquetumDto)
        {
            var etiqueta = _mapper.Map<Etiquetum>(etiquetumDto);
            etiqueta.Id = id;
            etiqueta.UpdatedAt = DateTime.Now;
            await _service.UpdateEtiqueta(etiqueta);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        
    }
    
}
