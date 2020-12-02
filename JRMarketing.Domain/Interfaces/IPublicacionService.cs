using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IPublicacionService
    {
        public IEnumerable<Publicacion> GetPublicacions();
        public Task<Publicacion> GetPublicacion(int id);
        public Task AddPublicacion(Publicacion publicacion);
        public Task UpdatePublicacion(Publicacion publicacion);
        public Task DeletePublicacion(int id);
    }
}
