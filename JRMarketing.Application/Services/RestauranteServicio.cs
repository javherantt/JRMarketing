using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Exceptions;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Expression<Func<Restaurante, bool>> expreRestaurante = item => item.NombreRestaurante == restaurante.NombreRestaurante;
            var restaurantes = _unitofWork.RestauranteRepository.FindByCondition(expreRestaurante);
            if (restaurantes.Any())
                throw new BusinessException("El nombre del restaurante ya existe");
            if (restaurante.TelefonoRestaurante != null)
            {
                Expression<Func<TelefonoRestaurante, bool>> expreTelefono = item => item.NumeroRestaurante == restaurante.TelefonoRestaurante.NumeroRestaurante;
                var telefonos = _unitofWork.TelefonoRestauranteRepository.FindByCondition(expreTelefono);
                if (telefonos.Any()) throw new BusinessException("El telefono esta siendo utilizado");
            }
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

        public IEnumerable<Restaurante> GetRestaurantes(RestauranteQueryFilter filter)
        {
            return _unitofWork.RestauranteRepository.GetRestaurantes(filter);
        }


        public async Task UpdateRestaurante(Restaurante restaurante)
        {
            _unitofWork.RestauranteRepository.Update(restaurante);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
