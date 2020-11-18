using JRMarketing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Domain.Interfaces
{
    public interface IUsuarioServices
    {
        public IEnumerable<Usuario> GetUsuarios();
        public Task<Usuario> GetUsuario(int id);
        public Task AddUsuario(Usuario usuario);
        public Task UpdateUsuario(Usuario usuario);
        public Task DeleteUsuario(int id);
    }
}
