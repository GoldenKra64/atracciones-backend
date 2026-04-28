using Atracciones.Backend.Business.DTOs.NoIncluye;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class NoIncluyeValidator
    {
        public static void ValidateCreate(CreateNoIncluyeRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (string.IsNullOrWhiteSpace(request.Descripcion))
                errors["Descripcion"] = new[] { "La descripción es obligatoria" };

            if (request.Descripcion.Length > 200)
                errors["Descripcion"] = new[] { "La descripción tiene un límite de 200 caracteres" };

            if (errors.Any())
                throw new ValidationException(errors);
        }

        public static void ValidateUpdate(UpdateNoIncluyeRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            ValidateCreate(request);
        }
    }
}
