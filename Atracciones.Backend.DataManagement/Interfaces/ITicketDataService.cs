using Atracciones.Backend.DataManagement.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface ITicketDataService
    {
        /* Task<List<TicketModel>> GetByAtraccionAsync(int atraccionId); */

        Task<int> CreateAsync(TicketCreateModel model);

        Task UpdateAsync(TicketUpdateModel model);

        Task SoftDeleteAsync(int id);
    }
}
