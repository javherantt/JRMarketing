using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IRestauranteEtiquetumService
    {
        public IEnumerable<RestauranteEtiquetum> Get();
        public RestauranteEtiquetum GetEtiquetum(int restau, int etique);
        public Task AddRestuaranteEtiquetum(RestauranteEtiquetum value);
        public Task UpdateRestauranteEtiqeutum(RestauranteEtiquetum value);
        public void DeleteRestauranteEtiquetum(int restau, int etique);
        public IEnumerable<RestauranteEtiquetum> GetRestauranteEtiqueta(int rest);
    }
}
