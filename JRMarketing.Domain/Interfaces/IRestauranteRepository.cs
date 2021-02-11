using JRMarketing.Domain.Entities;
using JRMarketing.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Domain.Interfaces
{
    public interface IRestauranteRepository : IRepository<Restaurante>
    {
        IEnumerable<Restaurante> GetRestaurantes(RestauranteQueryFilter filter);
    }
}
