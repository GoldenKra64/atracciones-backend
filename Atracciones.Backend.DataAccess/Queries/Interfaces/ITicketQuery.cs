using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries.Interfaces
{
    public interface ITicketQuery
    {
        Task<List<Ticket>> GetByAtraccionAsync(int atraccionId);
    }
}
