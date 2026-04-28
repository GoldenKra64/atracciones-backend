using Atracciones.Backend.DataAccess.Common;
using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries
{
    public class FacturaQuery : IFacturaQuery
    {
        private readonly AtraccionesDbContext _context;

        public FacturaQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Factura>> GetAllByClienteAsync(int cliId, int page, int size)
        {
            var query = _context.Facturas
                .Include(f => f.Reserva)
                .Where(f => f.Reserva.CliId == cliId);

            var total = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.FacFechaEmision)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return new PagedResult<Factura>
            {
                Items = items,
                TotalRecords = total,
                PageNumber = page,
                PageSize = size
            };
        }
        public async Task<List<Factura>> GetAllFacturasAsync()
        {
            return await _context.Facturas
                .OrderBy(x => x.FacFechaEmision)
                .ToListAsync();
        }
    }
}
