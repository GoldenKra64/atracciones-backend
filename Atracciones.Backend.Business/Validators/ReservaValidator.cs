using Atracciones.Backend.Business.DTOs.Reserva;
using Atracciones.Backend.Business.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class ReservaValidator
    {
        public static void ValidateCreate(CreateReservaRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (request.ClienteId <= 0)
                errors["ClienteId"] = new[] { "Cliente inválido" };

            if (request.Detalles == null || !request.Detalles.Any())
                errors["Detalles"] = new[] { "Debe incluir al menos un detalle" };

            foreach (var d in request.Detalles)
            {
                if (d.TicketId <= 0)
                    errors["TicketId"] = new[] { "Ticket inválido" };

                if (d.Cantidad <= 0)
                    errors["Cantidad"] = new[] { "Cantidad debe ser mayor a 0" };
            }

            if (request.DatosFacturacion == null)
                errors["DatosFacturacion"] = new[] { "Obligatorio" };

            ValidateDetalle(request.Detalles, errors);

            if (errors.Any())
                throw new ValidationException(errors);
        }
        private static void ValidateDetalle(IEnumerable<DetalleReservaRequest> detalles, Dictionary<string, string[]> errors)
        {
            for (int i = 0; i < detalles.Count(); i++)
            {
                ValidateDetalleReserva(detalles.ElementAt(i), errors, i);
            }
        }
        private static void ValidateDetalleReserva(DetalleReservaRequest detalle, Dictionary<string, string[]> errors, int index)
        {
            if (detalle.TicketId <= 0)
                errors[$"Detalles[{index}].TicketId"] = new[] { "Inválido" };

            if (detalle.Cantidad <= 0)
                errors[$"Detalles[{index}].Cantidad"] = new[] { "Debe ser mayor a 0" };
        }
    }
}
