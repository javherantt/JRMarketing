using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Infrastructure.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly JRMarketingContext _context;
        private readonly DbSet<T> _entity;

        public SQLRepository(JRMarketingContext context)
        {
            this._context = context;
            this._entity = context.Set<T>();
        }

        public async Task Add(T entity)
        { 
            if (entity == null) throw new ArgumentException("Entidad vacía");
            await _entity.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            if (id < 0) throw new ArgumentException("Entidad inválida");
            var entity = await GetById(id);
            _entity.Remove(entity);
        }

        public void DeleteRes(RestauranteEtiquetum entity)
        {
            _context.RestauranteEtiqueta.Remove(entity);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _entity.Where(expression).AsNoTracking().AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsNoTracking().AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == id);
        }    

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentException("Entidad vacía");
            if (entity.Id <= 0) throw new ArgumentException("Entidad inválida");
            _entity.Update(entity);
        }
    }
}
