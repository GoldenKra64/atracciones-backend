using Atracciones.Backend.DataAccess.Common;
using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries.Interfaces
{
    public interface IReservaQuery
    {
        Task<PagedResult<Reserva>> GetByClienteAsync(int clienteId, int page, int size);
        Task<Reserva?> GetDetalleAsync(int reservaId);
        Task<Reserva?> GetByIdAsync(string id);
    }
}
