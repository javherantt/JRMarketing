using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Infrastructure.Repositories
{
    public class EtiquetumRepository : IEtiquetumRepository
    {
        private readonly JRMarketingContext _context;

        public EtiquetumRepository(JRMarketingContext context)
        {
            this._context = context;
        }

        public async Task AddEtiquetum(Etiquetum etiquetum)
        {
            _context.Etiqueta.Add(etiquetum);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Etiquetum>> GetAll()
        {
            var etiquetas = await _context.Etiqueta.ToListAsync();
            return etiquetas;
        }

        public async Task<Etiquetum> GetEtiquetum(int id)
        {
            var etiqueta = await _context.Etiqueta.FirstOrDefaultAsync(etiqueta => etiqueta.IdEtiqueta == id);
            return etiqueta;
        }
    }
}
