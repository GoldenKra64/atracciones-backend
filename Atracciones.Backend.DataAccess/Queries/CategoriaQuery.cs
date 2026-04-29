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
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly AtraccionesDbContext _context;

        public CategoriaQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetTreeAsync()
        {
            return await _context.Categorias
                .Include(c => c.Children)
                .Where(c => c.CatParentId == null && c.CatEstado == "ACT")
                .ToListAsync();
        }
    }
}
