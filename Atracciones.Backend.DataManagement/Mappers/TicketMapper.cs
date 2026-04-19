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
                Nombre = entity.TicNombre,
                Precio = entity.TicPrecio,
                Stock = entity.TicStock,
                AtraccionId = entity.AtId
            };
        }

        public static Ticket ToEntity(TicketCreateModel model)
        {
            return new Ticket
            {
                AtId = model.AtraccionId,
                TicNombre = model.Nombre,
                TicPrecio = model.Precio,
                TicStock = model.Stock,
                TicEstado = "ACT"
            };
        }
        public static void UpdateEntity(Ticket entity, TicketUpdateModel model)
        {
            entity.TicNombre = model.Nombre;
            entity.TicPrecio = model.Precio;
            entity.TicStock = model.Stock;
        }
    }
}
