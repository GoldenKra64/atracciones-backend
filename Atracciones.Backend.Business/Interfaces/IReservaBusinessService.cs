using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IReservaBusinessService
    {
        /*Task<ReservaResponse> GetByIdAsync(int id);*/

        Task<PagedResponse<ReservaResponse>> GetByClienteAsync(
            int clienteId,
            int page,
            int size);

        Task<int> CreateAsync(CreateReservaRequest request);

        Task LogicalDeleteAsync(int id);
    }
}
