using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Repositories.Interfaces
{
    public interface IReservaRepository : IRepository<Reserva>
    {
        Task<int> CreateWithDetallesAsync(Reserva reserva);
        Task<Reserva> UpdateAsync(Reserva reserva);
        Task SoftDeleteAsync(string id);
        Task DeleteDetalleAsync(DetalleReserva detalle);
        Task ApproveAsync(string id);
    }
}
