using Atracciones.Backend.Business.DTOs.Ticket;
using Atracciones.Backend.DataManagement.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class TicketBusinessMapper
    {
        public static TicketCreateModel ToCreateModel(CreateTicketRequest request)
        {
            return new TicketCreateModel
            {
                AtraccionId = request.AtraccionId,
                Nombre = request.Nombre,
                Precio = request.Precio,
                Stock = request.Stock
            };
        }

        public static TicketUpdateModel ToUpdateModel(UpdateTicketRequest request)
        {
            return new TicketUpdateModel
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Precio = request.Precio,
                Stock = request.Stock
            };
        }

        public static TicketResponse ToResponse(TicketModel model)
        {
            return new TicketResponse
            {
                Id = model.Id,
                Guid = model.Guid,
                Nombre = model.Nombre,
                Precio = model.Precio,
                Stock = model.Stock
            };
        }
    }
}
