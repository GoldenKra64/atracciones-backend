using Atracciones.Backend.Business.DTOs.Resena;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class ResenaValidator
    {
        public static void ValidateCreate(CreateResenaRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (request.Calificacion < 1 || request.Calificacion > 5)
                errors["Calificacion"] = new[] { "Debe estar entre 1 y 5" };

            if (request.ClienteId <= 0)
                errors["ClienteId"] = new[] { "Cliente inválido" };

            if (request.AtraccionId <= 0)
                errors["AtraccionId"] = new[] { "Atracción inválida" };

            if (errors.Any())
                throw new ValidationException(errors);
        }

        public static void ValidateUpdate(UpdateResenaRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            ValidateCreate(new CreateResenaRequest
            {
                ClienteId = request.ClienteId,
                AtraccionId = request.AtraccionId,
                Calificacion = request.Calificacion,
                Comentario = request.Comentario
            });
        }
    }
}
