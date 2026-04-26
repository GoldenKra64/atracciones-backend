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
                rev_guid = entity.RevGuid,
                rev_estado = entity.RevEstado,
                rev_codigo = entity.RevCodigo,

                cli_id = entity.CliId,
                rev_fecha_reserva_utc = entity.RevFechaReservaUtc.ToShortDateString(),
                rev_subtotal = entity.RevSubtotal,
                rev_valor_iva = entity.RevValorIva,
                rev_total = entity.RevTotal,

                hor_fecha = entity.HorFecha ?? string.Empty,
                hor_hora_inicio = entity.HorHoraInicio ?? string.Empty,
                hor_hora_fin = entity.HorHoraFin ?? string.Empty,

                atraccion_nombre = entity.Detalles?.FirstOrDefault()?.Ticket?.Horario?.Atraccion?.AtNombre ?? string.Empty,
                moneda = "USD",

                detalle = entity.Detalles?
                    .Select(d => new DetalleReservaModel
                    {
                        tck_guid = d.Ticket.TicGuid,
                        tck_tipo_participante = d.TicTipoParticipante,
                        cantidad = d.TicCantidad,
                        precio_unit = d.TicPrecioUnitario,
                        subtotal = d.TicSubtotal
                    }).ToList() ?? new(),
            };
        }

        public static Reserva ToEntity(ReservaCreateModel model, Horario horario)
        {
            return new Reserva
            {
                CliId = model.ClienteId,
                RevGuid = Guid.NewGuid().ToString(),
                RevCodigo = $"R-{DateTime.UtcNow:yyyyMMddHHmmssfff}",
                HorHoraInicio = horario.HorHoraInicio.ToString(),
                HorFecha = horario.HorFecha.ToShortDateString(),
                HorHoraFin = horario.HorHoraFin.ToString() ?? "",
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
