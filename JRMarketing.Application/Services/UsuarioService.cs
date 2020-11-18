using JRMarketing.Domain.Entities;
using JRMarketing.Domain.Exceptions;
using JRMarketing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JRMarketing.Application.Services
{
    public class UsuarioService : IUsuarioServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddUsuario(Usuario usuario)
        {
            Expression<Func<Usuario, bool>> expreUsuario = item => item.NombreUsuario == usuario.NombreUsuario;
            var usuarios = _unitOfWork.UsuarioRepository.FindByCondition(expreUsuario);
            if (usuarios.Any()) throw new BusinessException("Nombre de usuario no válido");

            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int id)
        {
            await _unitOfWork.UsuarioRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _unitOfWork.UsuarioRepository.Update(usuario);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
