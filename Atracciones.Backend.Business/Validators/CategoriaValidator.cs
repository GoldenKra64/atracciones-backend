using Atracciones.Backend.Business.DTOs.Categoria;
using Microservicio.Clientes.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class CategoriaValidator
    {
        public static void ValidateCreate(CreateCategoriaRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Nombre))
                throw new ValidationException("Nombre obligatorio");
        }

        public static void ValidateUpdate(UpdateCategoriaRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            ValidateCreate(request);
        }
    }
}
