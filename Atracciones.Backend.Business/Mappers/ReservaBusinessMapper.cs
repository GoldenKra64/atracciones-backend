using Atracciones.Backend.Business.DTOs.Reserva;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class ReservaBusinessMapper
    {
        // 🔹 Request → Model
        public static ReservaCreateModel ToCreateModel(CreateReservaRequest request)
        {
            return new ReservaCreateModel
            {
                ClienteId = request.ClienteId,

                Detalles = request.Detalles.Select(d => new DetalleReservaModel
                {
                    TicketId = d.TicketId,
                    Cantidad = d.Cantidad
                }).ToList(),

                DatosFacturacion = new DatosFacturacionModel
                {
                    RazonSocial = request.DatosFacturacion.RazonSocial,
                    Ruc = request.DatosFacturacion.Ruc,
                    Direccion = request.DatosFacturacion.Direccion
                }
            };
        }

        // 🔹 Model → Response
        public static ReservaResponse ToResponse(ReservaModel model)
        {
            return new ReservaResponse
            {
                Id = model.Id,
                Guid = model.Guid,
                ClienteId = model.ClienteId,
                FechaReserva = model.FechaReserva,
                Total = model.Total,

                Detalles = model.Detalles.Select(d => new DetalleReservaResponse
                {
                    TicketId = d.TicketId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal
                }).ToList(),

                Factura = model.Factura != null
                    ? FacturaBusinessMapper.ToResponse(model.Factura)
                    : null
            };
        }
    }
}
