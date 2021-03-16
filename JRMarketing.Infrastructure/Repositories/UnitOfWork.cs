using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Infrastructure.Data;
using System.Threading.Tasks;

namespace JRMarketing.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly JRMarketingContext _context;
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IRepository<Etiquetum> _etiquetumRepository; 
        private readonly IRepository<Publicacion> _publicacionRepository;
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IRepository<TelefonoRestaurante> _telefonoRestauranteRepository;
        private readonly IRepository<TelefonoUsuario> _telefonoUsuarioRepository;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<RestauranteEtiquetum> _restauranteEtiquetumRepository;

        public UnitOfWork(JRMarketingContext context)
        {
            this._context = context;
        }

        public IRepository<Cliente> ClienteRepository => _clienteRepository ?? new SQLRepository<Cliente>(_context);

        public IRepository<Etiquetum> EtiquetumRepository => _etiquetumRepository ?? new SQLRepository<Etiquetum>(_context);

        public IRepository<Publicacion> PublicacionRepository => _publicacionRepository ?? new SQLRepository<Publicacion>(_context);

        public IRestauranteRepository RestauranteRepository => _restauranteRepository ?? new RestauranteRepository(_context);

        public IRepository<TelefonoRestaurante> TelefonoRestauranteRepository => _telefonoRestauranteRepository ?? new SQLRepository<TelefonoRestaurante>(_context);

        public IRepository<TelefonoUsuario> TelefonoUsuarioRepository => _telefonoUsuarioRepository ?? new SQLRepository<TelefonoUsuario>(_context);

        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new SQLRepository<Usuario>(_context);

        public IRepository<RestauranteEtiquetum> RestauranteEtiquetumRepository => _restauranteEtiquetumRepository ?? new SQLRepository<RestauranteEtiquetum>(_context);
      
        public void Dispose()
        {
            if (_context == null) _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
