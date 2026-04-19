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
    public class AtraccionQuery : IAtraccionQuery
    {
        private readonly AtraccionesDbContext _context;

        public AtraccionQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Atraccion>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? search,
            int? destinoId,
            int? categoriaId)
        {
            var query = _context.Atracciones
                .Include(a => a.Destino)
                .Include(a => a.Imagenes)
                .Include(a => a.CategoriaAtracciones)
                    .ThenInclude(ca => ca.Categoria)
                .Include(a => a.IncluyeAtracciones)
                    .ThenInclude(ia => ia.Atraccion)
                .AsQueryable();

            // 🔎 Filtros
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.AtNombre.Contains(search));
            }

            if (destinoId.HasValue)
            {
                query = query.Where(x => x.DesId == destinoId);
            }

            if (categoriaId.HasValue)
            {
                query = query.Where(x => x.CategoriaAtracciones
                    .Any(ca => ca.CatId == categoriaId));
            }

            var totalRecords = await query.CountAsync();

            var items = await query
                .OrderBy(x => x.AtNombre)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Atraccion>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Atraccion?> GetByIdAsync(int id)
        {
            return await _context.Atracciones
                .Include(a => a.Destino)
                .Include(a => a.Imagenes)
                .Include(a => a.CategoriaAtracciones)
                    .ThenInclude(c => c.Categoria)
                .Include(a => a.IdiomaAtracciones)
                    .ThenInclude(ia => ia.Idioma)
                .Include(a => a.IncluyeAtracciones)
                    .ThenInclude(ia => ia.Incluye)
                .FirstOrDefaultAsync(x => x.AtId == id);
        }
    }
}
