using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Application.Services
{
    public class ClienteService : IClienteServices
    {
        private readonly IUnitOfWork _unitofWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            this._unitofWork = unitOfWork;
        }

        public async Task AddCliente(Cliente cliente)
        {
            var clientes = _unitofWork.ClienteRepository.Add(cliente);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task DeleteCliente(int id)
        {
            await _unitofWork.ClienteRepository.Delete(id);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await _unitofWork.ClienteRepository.GetById(id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _unitofWork.ClienteRepository.GetAll();
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _unitofWork.ClienteRepository.Update(cliente);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
