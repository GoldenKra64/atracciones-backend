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
    public class IncluyeRepository : Repository<Incluye>, IIncluyeRepository
    {
        public IncluyeRepository(AtraccionesDbContext context) : base(context) { }

        public async Task<List<Incluye>> GetAllAsync()
        {
            return await _context.Incluyes
                .Where(i => i.IncEstado == "ACT")
                .ToListAsync();
        }
    }
}
