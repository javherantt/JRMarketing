using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Application.Services
{
    public class RestauranteServicio : IRestauranteServices
    {
        private readonly IUnitOfWork _unitofWork;

        public RestauranteServicio(IUnitOfWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }

        public async Task AddRestaurante(Restaurante restaurante)
        {
            await _unitofWork.RestauranteRepository.Add(restaurante);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task DeleteRestaurante(int id)
        {
            await _unitofWork.RestauranteRepository.Delete(id);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<Restaurante> GetRestaurante(int id)
        {
            return await _unitofWork.RestauranteRepository.GetById(id);
        }

        public IEnumerable<Restaurante> GetRestaurantes()
        {
            return _unitofWork.RestauranteRepository.GetAll();
        }

        public async Task UpdateRestaurante(Restaurante restaurante)
        {
            _unitofWork.RestauranteRepository.Update(restaurante);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
