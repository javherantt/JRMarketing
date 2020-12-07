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
    public class ClienteController : Controller
    {
        private readonly IClienteServices _service;
        private readonly IMapper _mapper;

        public ClienteController(IClienteServices service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var clientes = _service.GetClientes();
            var clientesDto = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteResponseDto>>(clientes);
            var response = new ApiResponse<IEnumerable<ClienteResponseDto>>(clientesDto);
            return Ok(response);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _service.GetCliente(id);
            var clienteDto = _mapper.Map<Cliente, ClienteResponseDto>(cliente);
            var response = new ApiResponse<ClienteResponseDto>(clienteDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteRequestDto clienteDto)
        {
            var cliente = _mapper.Map<ClienteRequestDto, Cliente>(clienteDto);
            await _service.AddCliente(cliente);
            var clienteResponseDto = _mapper.Map<Cliente, ClienteResponseDto>(cliente);
            var response = new ApiResponse<ClienteResponseDto>(clienteResponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCliente(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ClienteRequestDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            cliente.Id = id;
            cliente.UpdatedAt = DateTime.Now;
            await _service.UpdateCliente(cliente);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }
    }
}
 