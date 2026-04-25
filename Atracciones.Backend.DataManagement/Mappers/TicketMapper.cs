using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class TicketMapper
    {
        public static TicketModel ToModel(Ticket entity)
        {
            return new TicketModel
            {
                Id = entity.TicId,
                Guid = entity.TicGuid,
                Estado = entity.TicEstado,
                Nombre = entity.TicTitulo,
                Precio = entity.TicPrecio,
                Stock = entity.TicCuposDisponibles,
                HorarioId = entity.HorId,

                Horario = entity.Horario != null ? HorarioMapper.ToModel(entity.Horario) : null
            };
        }

        public static Ticket ToEntity(TicketCreateModel model)
        {
            return new Ticket
            {
                HorId = model.HorarioId,
                TicTitulo = model.Nombre,
                TicPrecio = model.Precio,
                TicCuposDisponibles = model.Stock,
                TicEstado = "ACT"
            };
        }
        public static void UpdateEntity(Ticket entity, TicketUpdateModel model)
        {
            entity.HorId = model.HorarioId;
            entity.TicTitulo = model.Nombre;
            entity.TicPrecio = model.Precio;
            entity.TicCuposDisponibles = model.Stock;
        }
    }
}
