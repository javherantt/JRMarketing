using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Infrastructure.Repositories
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly JRMarketingContext _context;

        public RestauranteRepository(JRMarketingContext context)
        {
            this._context = context;
        }

        public async Task AddRestaurante(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurante>> GetAll()
        {
            var restaurantes = await _context.Restaurantes.ToListAsync();
            return restaurantes;
        }

        public async Task<Restaurante> GetRestaurante(int id)
        {
            var restaurante = await _context.Restaurantes.FirstOrDefaultAsync(restau => restau.IdRestaurante == id);
            return restaurante;
        }
    }
}
