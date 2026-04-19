using Atracciones.Backend.Business.DTOs.Ticket;
using Microservicio.Clientes.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class TicketValidator
    {
        public static void ValidateCreate(CreateTicketRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (string.IsNullOrWhiteSpace(request.Nombre))
                errors["Nombre"] = new[] { "Obligatorio" };

            if (request.Precio <= 0)
                errors["Precio"] = new[] { "Debe ser mayor a 0" };

            if (request.Stock < 0)
                errors["Stock"] = new[] { "No puede ser negativo" };

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }
}
