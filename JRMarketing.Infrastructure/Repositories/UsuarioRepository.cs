using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Interfaces;
using JRMarketing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRMarketing.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly JRMarketingContext _context;

        public UsuarioRepository(JRMarketingContext context)
        {
            this._context = context;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.IdUsuario == id);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }
    }
}
