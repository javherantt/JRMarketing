using System;
using JRMarketing.Domain.Entities;
using JRMarketing.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable

namespace JRMarketing.Infrastructure.Data
{
    public partial class JRMarketingContext : DbContext
    {
        public JRMarketingContext()
        {
        }

        public JRMarketingContext(DbContextOptions<JRMarketingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Etiquetum> Etiqueta { get; set; }    
        public virtual DbSet<Publicacion> Publicacions { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<RestauranteEtiquetum> RestauranteEtiqueta { get; set; }
        public virtual DbSet<TelefonoRestaurante> TelefonoRestaurantes { get; set; }
        public virtual DbSet<TelefonoUsuario> TelefonoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<EtiquetumName> EtiquetasName { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Etiquetum>(new EtiquetumConfiguration());       
            modelBuilder.ApplyConfiguration<Publicacion>(new PublicacionConfiguration());
            modelBuilder.ApplyConfiguration<Restaurante>(new RestauranteConfiguration());
            modelBuilder.ApplyConfiguration<RestauranteEtiquetum>(new RestauranteEtiquetumConfiguration());
            modelBuilder.ApplyConfiguration<TelefonoRestaurante>(new TelefonoRestauranteConfiguration());
            modelBuilder.ApplyConfiguration<TelefonoUsuario>(new TelefonoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());

            modelBuilder.Entity<EtiquetumName>().HasNoKey();
        }

    }
}
