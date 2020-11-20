using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IClienteServices
    {
        public IEnumerable<Cliente> GetClientes();
        public Task<Cliente> GetCliente(int id);
        public Task AddCliente(Cliente cliente);
        public Task UpdateCliente(Cliente cliente);
        public Task DeleteCliente(int id);
    }
}
