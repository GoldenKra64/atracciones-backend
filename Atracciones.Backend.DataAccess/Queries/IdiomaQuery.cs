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
    public class IdiomaQuery : IIdiomaQuery
    {
        private readonly AtraccionesDbContext _context;

        public IdiomaQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Idioma>> GetAllAsync()
        {
            return await _context.Idiomas
                .OrderBy(x => x.IdNombre)
                .ToListAsync();
        }
    }
}
