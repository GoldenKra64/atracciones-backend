using Atracciones.Backend.Business.DTOs.Factura;
using Microservicio.Clientes.Business.Exceptions;
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

            if (string.IsNullOrWhiteSpace(request.RazonSocial))
                errors["RazonSocial"] = new[] { "Obligatorio" };

            if (string.IsNullOrWhiteSpace(request.Ruc))
                errors["Ruc"] = new[] { "Obligatorio" };

            if (request.Ruc?.Length < 10)
                errors["Ruc"] = new[] { "RUC inválido" };

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }
}
