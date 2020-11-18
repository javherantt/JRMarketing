using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IEtiquetumService
    {
        public IEnumerable<Etiquetum> GetEtiquetas();
        public Task<Etiquetum> GetEtiqueta(int id);
        public Task AddEtiqueta(Etiquetum etiquetum);
        public Task UpdateEtiqueta(Etiquetum etiquetum);
        public Task DeleteEtiqueta(int id);

    }
}
