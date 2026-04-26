using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class ReservaMapper
    {
        public static ReservaModel ToModel(Reserva entity)
        {
            return new ReservaModel
            {
                Id = entity.RevId,
                Guid = entity.RevGuid,
                Estado = entity.RevEstado,

                ClienteId = entity.CliId,
                FechaReserva = entity.RevFechaReservaUtc,
                Total = entity.RevTotal,

                Detalles = entity.Detalles?
                    .Select(d => new DetalleReservaModel
                    {
                        TicketId = d.Ticket.TicGuid,
                        Cantidad = d.TicCantidad,
                        PrecioUnitario = d.TicPrecioUnitario,
                        Subtotal = d.TicSubtotal
                    }).ToList() ?? new(),

                Factura = entity.Factura != null
                    ? FacturaMapper.ToModel(entity.Factura)
                    : null
            };
        }

        public static Reserva ToEntity(ReservaCreateModel model)
        {
            return new Reserva
            {
                CliId = model.ClienteId,
                RevGuid = Guid.NewGuid().ToString(),
                RevCodigo = $"R-{DateTime.UtcNow:yyyyMMddHHmmssfff}",
                RevFechaReservaUtc = DateTime.UtcNow,
                RevEstado = "PEN",
                RevIpIngreso = "127.0.0.1",
                RevUsuarioIngreso = "system",
                RevCanal = model.Canal,
                Detalles = new List<DetalleReserva>()
            };
        }
    }
}
