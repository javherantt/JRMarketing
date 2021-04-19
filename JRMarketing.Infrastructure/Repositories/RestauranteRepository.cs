using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Domain.QueryFilters;
using JRMarketing.Infrastructure.Data;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Infrastructure.Repositories
{
    public class RestauranteRepository : SQLRepository<Restaurante>, IRestauranteRepository
    {
        private readonly JRMarketingContext _context;

        public RestauranteRepository(JRMarketingContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<EtiquetumName> GetEtiquetasName()
        {
            return _context.EtiquetasName.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<Restaurante> GetRestaurantes(RestauranteQueryFilter filter)
        {
            Expression<Func<Restaurante, bool>> expreFinal = restuarante => restuarante.Id > 0;

            if(!string.IsNullOrEmpty(filter.NombreRestaurante) && !string.IsNullOrWhiteSpace(filter.NombreRestaurante))
            {
                Expression<Func<Restaurante, bool>> expresion = restuarante => restuarante.NombreRestaurante.Contains(filter.NombreRestaurante);
                expreFinal = expreFinal.And(expresion);
            }

            if(!string.IsNullOrEmpty(filter.EstadoR) && !string.IsNullOrWhiteSpace(filter.EstadoR))
            {
                Expression<Func<Restaurante, bool>> expresion = restaurante => restaurante.EstadoR.Contains(filter.EstadoR);
                expreFinal = expreFinal.And(expresion);
            }

            return FindByCondition(expreFinal);
        }

        public IEnumerable<Restaurante> GetRestaurantesFilter(RestauranteQueryFilter filter)
        {
            List<Restaurante> restaurantesAll = new List<Restaurante>();
            if((!string.IsNullOrEmpty(filter.NombreRestaurante) && !string.IsNullOrWhiteSpace(filter.NombreRestaurante)) && 
                (!string.IsNullOrWhiteSpace(filter.EstadoR) && !string.IsNullOrWhiteSpace(filter.EstadoR)))
            {
                var restaurants = _context.Restaurantes.FromSqlRaw($"SELECT * FROM Restaurante LEFT OUTER JOIN EtiquetasName on ID=IdRestau where " +
                    $"(NombreRestaurante like '%{filter.NombreRestaurante}%' or NombreEtiqueta like '%{filter.NombreRestaurante}%') and (EstadoR='{filter.EstadoR}')");
                restaurantesAll = restaurants.ToList();
                return restaurantesAll;
            }

            if((!string.IsNullOrEmpty(filter.EstadoR) && !string.IsNullOrWhiteSpace(filter.EstadoR)) && 
                (string.IsNullOrEmpty(filter.NombreRestaurante) && string.IsNullOrWhiteSpace(filter.NombreRestaurante)))
            {
                var restaurants = _context.Restaurantes.FromSqlRaw($"SELECT * FROM Restaurante where EstadoR='{filter.EstadoR}'");
                restaurantesAll = restaurants.ToList();
                return restaurantesAll;
            }

            if((!string.IsNullOrEmpty(filter.NombreRestaurante) && !string.IsNullOrWhiteSpace(filter.NombreRestaurante)) && 
                (string.IsNullOrEmpty(filter.EstadoR) && string.IsNullOrWhiteSpace(filter.EstadoR)))
            {
                var restaurants = _context.Restaurantes.FromSqlRaw($"SELECT * FROM Restaurante LEFT OUTER JOIN EtiquetasName on ID=IdRestau where " +
                    $"NombreRestaurante like '%{filter.NombreRestaurante}%' or NombreEtiqueta like '%{filter.NombreRestaurante}%'");
                restaurantesAll = restaurants.ToList();
                return restaurantesAll;
            }
            else
            {
                return GetAll();
            }                 

        }     
    }
}
