using Atracciones.Backend.Business.DTOs.Imagen;
using Microservicio.Clientes.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class ImagenValidator
    {
        public static void ValidateCreate(CreateImagenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Url))
                throw new ValidationException("Url obligatoria");
        }
    }
}
