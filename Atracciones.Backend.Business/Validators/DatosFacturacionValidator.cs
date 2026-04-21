using Atracciones.Backend.Business.DTOs.Factura;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class DatosFacturacionValidator
    {
        public static void Validate(DatosFacturacionRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (string.IsNullOrWhiteSpace(request.Apellidos) || string.IsNullOrWhiteSpace(request.Nombres))
                errors["Nombres"] = new[] { "Obligatorio" };

            if (string.IsNullOrWhiteSpace(request.Telefono))
                errors["Telefono"] = new[] { "Obligatorio" };

            if (string.IsNullOrWhiteSpace(request.Correo))
                errors["Correo"] = new[] { "Obligatorio" };

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }
}
