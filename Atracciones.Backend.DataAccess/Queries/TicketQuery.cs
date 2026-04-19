using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries
{
    public class TicketQuery : ITicketQuery
    {
        private readonly AtraccionesDbContext _context;

        public TicketQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetByAtraccionAsync(int atraccionId)
        {
            return await _context.Tickets
                .Where(t => t.AtId == atraccionId)
                .ToListAsync();
        }
    }
}
