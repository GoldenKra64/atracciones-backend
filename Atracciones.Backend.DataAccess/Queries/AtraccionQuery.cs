using Atracciones.Backend.DataAccess.Common;
using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataAccess.Filters;
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
        public async Task<PagedResult<Atraccion>> SearchAsync(AtraccionFilterModel filter)
        {
            var query = _context.Atracciones
                .AsNoTracking()
                .Include(x => x.Destino)
                .Include(x => x.Imagenes)
                .Include(x => x.CategoriaAtracciones).ThenInclude(ca => ca.Categoria)
                .Include(x => x.IdiomaAtracciones).ThenInclude(ia => ia.Idioma)
                .Include(x => x.IncluyeAtracciones).ThenInclude(ia => ia.Incluye)
                .Where(x => x.AtEstado == "ACT")
                .AsQueryable();

            // 🔍 Nombre
            if (!string.IsNullOrWhiteSpace(filter.Nombre))
            {
                query = query.Where(x => x.AtNombre.Contains(filter.Nombre));
            }

            // 📍 Destino
            if (filter.DestinoId.HasValue)
            {
                query = query.Where(x => x.DesId == filter.DestinoId);
            }

            // 🏷️ Categorías
            if (filter.CategoriaIds != null && filter.CategoriaIds.Any())
            {
                query = query.Where(x =>
                    x.CategoriaAtracciones.Any(ca => filter.CategoriaIds.Contains(ca.CatId)));
            }

            // 🌐 Idiomas
            if (filter.IdiomaIds != null && filter.IdiomaIds.Any())
            {
                query = query.Where(x =>
                    x.IdiomaAtracciones.Any(ia => filter.IdiomaIds.Contains(ia.IdiId)));
            }

            // 💰 Precio
            if (filter.PrecioMin.HasValue)
            {
                query = query.Where(x => x.AtPrecioReferencia >= filter.PrecioMin);
            }

            if (filter.PrecioMax.HasValue)
            {
                query = query.Where(x => x.AtPrecioReferencia <= filter.PrecioMax);
            }

            // 🚐 Transporte
            if (filter.IncluyeTransporte.HasValue)
            {
                query = query.Where(x => x.AtIncluyeTransporte == filter.IncluyeTransporte);
            }

            // 📊 Total
            var totalRecords = await query.CountAsync();

            // 📄 Paginación
            var items = await query
                .OrderBy(x => x.AtNombre)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<Atraccion>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }
    }
}
