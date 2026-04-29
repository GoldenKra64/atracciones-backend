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
    public class AtraccionRepository : Repository<Atraccion>, IAtraccionRepository
    {
        public AtraccionRepository(AtraccionesDbContext context) : base(context) { }

        public async Task SoftDeleteAsync(string id)
        {
            var entity = await _context.Atracciones.Where(c => c.AtGuid == id).FirstOrDefaultAsync();

            entity.AtEstado = "INA";

            await _context.SaveChangesAsync();
        }
    }
}
