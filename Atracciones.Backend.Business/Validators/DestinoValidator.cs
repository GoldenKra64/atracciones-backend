using Atracciones.Backend.Business.DTOs.Destino;
using Microservicio.Clientes.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class DestinoValidator
    {
        public static void ValidateCreate(CreateDestinoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Nombre))
                throw new ValidationException("Nombre obligatorio");
        }

        public static void ValidateUpdate(UpdateDestinoRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            ValidateCreate(request);
        }
    }
}
