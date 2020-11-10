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
    [ApiController]
    public class EtiquetumController : Controller
    {
        private readonly IEtiquetumRepository _repository;
        private readonly IMapper _mapper;

        public EtiquetumController(IEtiquetumRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var etiquetas = await _repository.GetAll();
            var etiquetasDto = _mapper.Map<IEnumerable<Etiquetum>, IEnumerable<EtiquetumResponseDto>>(etiquetas);
            return Ok(etiquetasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var etiqueta = await _repository.GetEtiquetum(id);
            var etiquetasDto = _mapper.Map<Etiquetum, EtiquetumResponseDto>(etiqueta);
            return Ok(etiquetasDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EtiquetumRequestDto etiquetumDto)
        {
            var etiqueta = _mapper.Map<Etiquetum>(etiquetumDto);
            await _repository.AddEtiquetum(etiqueta);
            var etiquetaResponseDto = _mapper.Map<EtiquetumResponseDto>(etiqueta);
            return Ok(etiquetaResponseDto);
        }
    }
}
