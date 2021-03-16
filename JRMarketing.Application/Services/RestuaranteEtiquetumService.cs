using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Application.Services
{
    public class RestuaranteEtiquetumService : IRestauranteEtiquetumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestuaranteEtiquetumService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddRestuaranteEtiquetum(RestauranteEtiquetum value)
        {
            Expression<Func<RestauranteEtiquetum, bool>> expreRestaurant = item => item.IdEtiquetaRestau == value.IdEtiquetaRestau && item.IdRestauranteEtiq == value.IdRestauranteEtiq;
            var restaurantesEti = _unitOfWork.RestauranteEtiquetumRepository.FindByCondition(expreRestaurant);
            if (restaurantesEti.Any())
                throw new ArgumentException("El valor ya ha sido registrado");
            await _unitOfWork.RestauranteEtiquetumRepository.Add(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public void DeleteRestauranteEtiquetum(int restaurante, int etiqueta)
        {
            Expression<Func<RestauranteEtiquetum, bool>> expreRestaurant = item => item.IdEtiquetaRestau == etiqueta && item.IdRestauranteEtiq == restaurante;
            var restauranteEtiqueta = _unitOfWork.RestauranteEtiquetumRepository.FindByCondition(expreRestaurant);
            if (restauranteEtiqueta == null) throw new ArgumentException("El elemento no existe");
            var value = restauranteEtiqueta.FirstOrDefault(e => e.IdEtiquetaRestau == etiqueta && e.IdRestauranteEtiq == restaurante);
            _unitOfWork.RestauranteEtiquetumRepository.DeleteRes(value);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<RestauranteEtiquetum> Get()
        {
            return _unitOfWork.RestauranteEtiquetumRepository.GetAll();
        }

        public RestauranteEtiquetum GetEtiquetum(int restaurante, int etiqueta)
        {
            Expression<Func<RestauranteEtiquetum, bool>> expreRestaurant = item => item.IdEtiquetaRestau == etiqueta && item.IdRestauranteEtiq == restaurante;
            var restauranteEtiqueta = _unitOfWork.RestauranteEtiquetumRepository.FindByCondition(expreRestaurant);
            var value = restauranteEtiqueta.FirstOrDefault(e => e.IdRestauranteEtiq == restaurante && e.IdEtiquetaRestau == etiqueta);
            if(value == null)
                return null;
            else return value;
        }

        public IEnumerable<RestauranteEtiquetum> GetRestauranteEtiqueta(int rest)
        {
            Expression<Func<RestauranteEtiquetum, bool>> expreRestaurant = item => item.IdRestauranteEtiq == rest;
            var restuarantEtiquetum = _unitOfWork.RestauranteEtiquetumRepository.FindByCondition(expreRestaurant);
            if (restuarantEtiquetum == null) return null;
            else return restuarantEtiquetum;
        }

        public async Task UpdateRestauranteEtiqeutum(RestauranteEtiquetum value)
        {
            _unitOfWork.RestauranteEtiquetumRepository.Update(value);
            await _unitOfWork.SaveChangesAsync();
        }        
    }
        
}
