using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Application.Services
{
    public class PublicacionService : IPublicacionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicacionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddPublicacion(Publicacion publicacion)
        {
            await _unitOfWork.PublicacionRepository.Add(publicacion);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePublicacion(int id)
        {
            await _unitOfWork.PublicacionRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Publicacion> GetPublicacion(int id)
        {
            return await _unitOfWork.PublicacionRepository.GetById(id);

        }

        public IEnumerable<Publicacion> GetPublicacions()
        {
            return _unitOfWork.PublicacionRepository.GetAll();
        }

        public async Task UpdatePublicacion(Publicacion publicacion)
        {
            _unitOfWork.PublicacionRepository.Update(publicacion);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
