using Atracciones.Backend.Business.DTOs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface ITicketBusinessService
    {
        Task<IEnumerable<TicketResponse>> GetByAtraccionAsync(int atraccionId);

        Task<int> CreateAsync(CreateTicketRequest request);

        Task UpdateAsync(UpdateTicketRequest request);

        Task LogicalDeleteAsync(int id);
    }
}
