using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IRestauranteEtiquetumRepository
    {
        Task Add(RestauranteEtiquetum restauranteEtiquetum);
        Task Delete(int restaurante, int etiqueta);
        IEnumerable<RestauranteEtiquetum> FindByCondition(Expression<Func<RestauranteEtiquetum, bool>> expression);
        IEnumerable<RestauranteEtiquetum> GetAll();
        Task<RestauranteEtiquetum> GetById(int restaurante, int etiquetum);
        void Update(RestauranteEtiquetum entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
