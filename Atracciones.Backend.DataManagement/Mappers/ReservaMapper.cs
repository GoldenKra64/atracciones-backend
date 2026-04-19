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
                Id = entity.ResId,
                Guid = entity.ResGuid,
                Estado = entity.ResEstado,

                ClienteId = entity.CliId,
                FechaReserva = entity.ResFechaReserva,
                Total = entity.ResTotal,

                Detalles = entity.Detalles?
                    .Select(d => new DetalleReservaModel
                    {
                        TicketId = d.TicId,
                        Cantidad = d.DetCantidad,
                        PrecioUnitario = d.DetPrecioUnitario,
                        Subtotal = d.DetSubtotal
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
                ResFechaReserva = DateTime.UtcNow,
                ResEstado = "ACT",

                Detalles = model.Detalles.Select(d => new DetalleReserva
                {
                    TicId = d.TicketId,
                    DetCantidad = d.Cantidad,
                    DetPrecioUnitario = d.PrecioUnitario,
                    DetSubtotal = d.Subtotal
                }).ToList()
            };
        }
    }
}
