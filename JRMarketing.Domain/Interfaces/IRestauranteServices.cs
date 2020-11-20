using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IRestauranteServices
    {
        public IEnumerable<Restaurante> GetRestaurantes();
        public Task<Restaurante> GetRestaurante(int id);
        public Task AddRestaurante(Restaurante restaurante);
        public Task UpdateRestaurante(Restaurante restaurante);
        public Task DeleteRestaurante(int id);
    }
}
