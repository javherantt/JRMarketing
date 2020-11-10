using JRMarketing.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> GetAll();
        public Task<Usuario> GetUsuario(int id);
        public Task AddUsuario(Usuario usuario);
    }
}
