﻿using JRMarketing.Domain.Entities;
using JRMarketing.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IRestauranteServices
    {
        public IEnumerable<Restaurante> GetRestaurantes(RestauranteQueryFilter filter);
        public Task<Restaurante> GetRestaurante(int id);
        public Task AddRestaurante(Restaurante restaurante);
        public Task UpdateRestaurante(Restaurante restaurante);
        public Task DeleteRestaurante(int id);
        public IEnumerable<EtiquetumName> GetEtiquetasName();
        public IEnumerable<Restaurante> GetRestaurantesFilter(RestauranteQueryFilter filter);
    }
}
