using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(AtraccionesDbContext context) : base(context) {
        }

        public Task<Ticket?> GetByIdAsync(string tickGuid)
        {
            return _context.Tickets.FirstOrDefaultAsync(t => t.TicGuid == tickGuid);
        }
    }
}
