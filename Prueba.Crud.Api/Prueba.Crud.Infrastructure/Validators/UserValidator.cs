using FluentValidation;
using Prueba.Crud.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Crud.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            //Validacion de todos lo campos Ingresando a la Api
            // miercoles 2 de marzo

            RuleFor(user => user.Id_User)
                .NotNull()
                .WithMessage("El Nombre no puede ser nulo");

            RuleFor(user => user.LastName)
                .NotNull()
                .WithMessage("El Apellido no puede ser nulo");

            RuleFor(user => user.LastName)
              .NotNull()
              .WithMessage("El Apellido no puede ser nulo");

            RuleFor(user => user.Document_Type)
              .NotNull()
              .WithMessage("El Tipo Documento no puede ser nulo");

            RuleFor(user => user.Birth_date)
              .NotNull()
              .WithMessage("La Fecha de Nacimiento no puede ser nulo");

            RuleFor(user => user.Value_to_win)
              .NotNull()
              .WithMessage("El Valor a Ganar  no puede ser nulo");

            RuleFor(user => user.Civil_Status)
            .NotNull()
            .WithMessage("El Estado civil  no puede ser nulo");
        }
    }
}
