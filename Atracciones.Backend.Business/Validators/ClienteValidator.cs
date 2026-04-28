using Atracciones.Backend.Business.DTOs.Cliente;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class ClienteValidator
    {
        public static void ValidateCreate(CreateClienteRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            // Nombre (solo dígitos)
            if (string.IsNullOrWhiteSpace(request.Nombres))
            {
                errors["Nombres"] = new[] { "El nombre del cliente no puede ir vacio" };
            }

            // Apellidos (solo dígitos)
            if (string.IsNullOrWhiteSpace(request.Apellidos))
            {
                errors["Apellidos"] = new[] { "El apellido no puede ir vacio" };
            }


            // Correo
            if (string.IsNullOrWhiteSpace(request.Correo))
            {
                errors["Correo"] = new[] { "Correo obligatorio" };
            }
            else if (!request.Correo.Contains("@"))
            {
                errors["Correo"] = new[] { "Correo inválido" };
            }

            // Identificación
            if (string.IsNullOrWhiteSpace(request.NumeroIdentificacion))
            {
                errors["Identificacion"] = new[] { "Obligatorio" };
            }

            // Teléfono (solo dígitos)
            if (!request.Telefono.All(char.IsDigit))
            {
                errors["Telefono"] = new[] { "El teléfono solo debe contener números" };
            }

            // CEDULA
            if (string.IsNullOrWhiteSpace(request.NumeroIdentificacion))
            {
                errors["Numero Identificacion"] = new[] { "El numero de identificación no puede ir vacio" };
            }
            if (!request.NumeroIdentificacion.All(char.IsDigit))
            {
                errors["Numero Identificacion"] = new[] { "El numero de identificacion solo debe contener números" };
            }

            // Tipo de identificación válido
            var tiposValidos = new[] { "CEDULA", "RUC", "PASAPORTE" };

            if (string.IsNullOrWhiteSpace(request.TipoIdentificacion) ||
                !tiposValidos.Contains(request.TipoIdentificacion.ToUpper()))
                    {
                        errors["TipoIdentificacion"] = new[]
                        {
                    "Solo puede ser: CEDULA, RUC o PASAPORTE"
                };
            }

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
