using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Exceptions;
using JRMarketing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Application.Services
{
    public class EtiquetumService : IEtiquetumService
    {
        private readonly IUnitOfWork _unitofWork;
        public EtiquetumService(IUnitOfWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        public async Task AddEtiqueta(Etiquetum etiquetum)
        {
            Expression<Func<Etiquetum, bool>> expreEtiquetum = item => item.NombreEtiqueta == etiquetum.NombreEtiqueta;
            var etiquetas = _unitofWork.EtiquetumRepository.FindByCondition(expreEtiquetum);
            if (etiquetas.Any()) throw new BusinessException("El nombre de la etiqueta ya existe");

            await _unitofWork.EtiquetumRepository.Add(etiquetum);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task DeleteEtiqueta(int id)
        {
            await _unitofWork.EtiquetumRepository.Delete(id);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<Etiquetum> GetEtiqueta(int id)
        {
            return await _unitofWork.EtiquetumRepository.GetById(id);
        }

        public IEnumerable<Etiquetum> GetEtiquetas()
        {
            return _unitofWork.EtiquetumRepository.GetAll();
        }

        public async Task UpdateEtiqueta(Etiquetum etiquetum)
        {
            Expression<Func<Etiquetum, bool>> expreEtiquetum = item => item.NombreEtiqueta == etiquetum.NombreEtiqueta;
            var etiquetas = _unitofWork.EtiquetumRepository.FindByCondition(expreEtiquetum);
            if (etiquetas.Any()) throw new BusinessException("El nombre de la etiqueta ya existe");

            _unitofWork.EtiquetumRepository.Update(etiquetum);
            await _unitofWork.SaveChangesAsync();
        }
    }
}
