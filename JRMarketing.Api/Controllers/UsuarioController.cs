using AutoMapper;
using JRMarketing.Domain.DTOs;
using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRMarketing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.GetAll();
            var usuariosDto = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(usuarios);
            return Ok(usuariosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _repository.GetUsuario(id);
            var usuarioDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequestDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _repository.AddUsuario(usuario);
            var usuarioResponseDto = _mapper.Map<UsuarioResponseDto>(usuario);
            return Ok(usuarioResponseDto);
        }
    }
}
