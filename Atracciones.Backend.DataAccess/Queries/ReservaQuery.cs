using Atracciones.Backend.DataAccess.Common;
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
    public class ReservaQuery : IReservaQuery
    {
        private readonly AtraccionesDbContext _context;

        public ReservaQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Reserva>> GetByClienteAsync(int clienteId, int page, int size)
        {
            var query = _context.Reservas
                .Include(r => r.Detalles)
                    .ThenInclude(d => d.Ticket)
                .Include(r => r.Factura)
                .Where(r => r.CliId == clienteId);

            var total = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.RevFechaReservaUtc)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return new PagedResult<Reserva>
            {
                Items = items,
                TotalRecords = total,
                PageNumber = page,
                PageSize = size
            };
        }

        public async Task<Reserva?> GetDetalleAsync(int reservaId)
        {
            return await _context.Reservas
                .Include(r => r.Detalles)
                    .ThenInclude(d => d.Ticket)
                        .ThenInclude(t => t.Horario)
                            .ThenInclude(h => h.Atraccion)
                .Include(r => r.Factura)
                .FirstOrDefaultAsync(r => r.RevId == reservaId);
        }

        public async Task<Reserva?> GetByIdAsync(string id)
        {
            return await _context.Reservas
                .Include(r => r.Detalles)
                    .ThenInclude(d => d.Ticket)
                        .ThenInclude(t => t.Horario)
                            .ThenInclude(h => h.Atraccion).AsTracking()
                .FirstOrDefaultAsync(r => r.RevGuid == id);
        }

        public async Task<List<Reserva?>> GetAllAsync()
        {
            return await _context.Reservas
                .Include(r => r.Detalles)
                    .ThenInclude(x => x.Ticket)
                        .ThenInclude(x => x.Horario)
                            .ThenInclude(x => x.Atraccion).Where(x => x.RevEstado == "PEN").ToListAsync();
        }
    }
}
