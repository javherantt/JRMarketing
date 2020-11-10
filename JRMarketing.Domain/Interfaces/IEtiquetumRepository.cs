using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IEtiquetumRepository
    {
        public Task<IEnumerable<Etiquetum>> GetAll();
        public Task<Etiquetum> GetEtiquetum(int id);
        public Task AddEtiquetum(Etiquetum etiquetum);
    }
}
