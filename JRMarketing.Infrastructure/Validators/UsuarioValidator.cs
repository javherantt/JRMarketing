using FluentValidation;
using JRMarketing.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace JRMarketing.Infrastructure.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequestDto>
    {
        public UsuarioValidator()
        {
            RuleFor(usuario => usuario.NombreUsuario)
                .NotNull()
                .NotEmpty()
                .Length(6, 25);
            RuleFor(usuario => usuario.Contrasenia)
                .NotNull()
                .NotEmpty()
                .Length(6, 25);
            RuleFor(usuario => usuario.Nombre)
                .NotNull()
                .NotEmpty()
                .Length(3, 50);
            RuleFor(usuario => usuario.Apellidos)
                .NotNull()
                .NotEmpty()
                .Length(3, 50);
            RuleFor(usuario => usuario.Correo)
                .NotNull()
                .NotEmpty()
                .EmailAddress();              
        }
    }
}
