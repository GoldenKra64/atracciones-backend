using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Repositories
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        public FacturaRepository(AtraccionesDbContext context) : base(context) { }

        public async Task<Factura?> GetByReservaAsync(int reservaId)
        {
            return await _context.Facturas.FirstOrDefaultAsync(f => f.RevId == reservaId);
        }
    }
}
