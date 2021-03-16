﻿using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Cliente> ClienteRepository { get; }
        public IRepository<Etiquetum> EtiquetumRepository { get; }
        public IRepository<Publicacion> PublicacionRepository { get; }
        public IRestauranteRepository RestauranteRepository { get; }
        public IRepository<TelefonoRestaurante> TelefonoRestauranteRepository { get; }
        public IRepository<TelefonoUsuario> TelefonoUsuarioRepository { get; }
        public IRepository<Usuario> UsuarioRepository { get; }
        public IRepository<RestauranteEtiquetum> RestauranteEtiquetumRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
