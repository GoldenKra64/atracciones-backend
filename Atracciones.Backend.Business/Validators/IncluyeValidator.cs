using Atracciones.Backend.Business.DTOs.Incluye;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class IncluyeValidator
    {
        public static void ValidateCreate(CreateIncluyeRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Descripcion))
                throw new ValidationException("La descripción es obligatoria");

            if (request.Descripcion.Length > 200)
                throw new ValidationException("Máximo 200 caracteres");
        }

        public static void ValidateUpdate(UpdateIncluyeRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            ValidateCreate(request);
        }
    }
}
