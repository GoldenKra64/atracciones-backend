using Atracciones.Backend.Business.DTOs.Cliente;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class ClienteValidator
    {
        public static void ValidateCreate(CreateClienteRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (string.IsNullOrWhiteSpace(request.Correo))
                errors["Correo"] = new[] { "Correo obligatorio" };

            if (!request.Correo.Contains("@"))
                errors["Correo"] = new[] { "Correo inválido" };

            if (string.IsNullOrWhiteSpace(request.NumeroIdentificacion))
                errors["Identificacion"] = new[] { "Obligatorio" };

            if (errors.Any())
                throw new ValidationException(errors);
        }

        public static void ValidateUpdate(UpdateClienteRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            ValidateCreate(request);
        }
    }
}
