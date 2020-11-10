using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IRestauranteRepository
    {
        public Task<IEnumerable<Restaurante>> GetAll();
        public Task<Restaurante> GetRestaurante(int id);
        public Task AddRestaurante(Restaurante restaurante);
    }
}
