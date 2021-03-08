using AutoMapper;
using JRMarketing.Api.Responses;
using JRMarketing.Domain.DTOs;
using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRMarketing.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServices _service;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServices service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _service.GetUsuarios();
            var usuariosDto = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioResponseDto>>(usuariosDto);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _service.GetUsuario(id);
            var usuarioDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequestDto usuarioDto)
        {
            var usuario = _mapper.Map<UsuarioRequestDto, Usuario>(usuarioDto);
            await _service.AddUsuario(usuario);
            var usuarioResponseDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioResponseDto);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteUsuario(id);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put (int id, Usuario usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.Id = id;
            usuario.UpdatedAt = DateTime.Now;
            usuario.CreatedAt = DateTime.Now;

            await _service.UpdateUsuario(usuario);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
   
}
