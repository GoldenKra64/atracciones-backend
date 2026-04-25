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
    public class TagQuery : ITagQuery
    {
        private readonly AtraccionesDbContext _context;

        public TagQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags
                .OrderBy(x => x.TagDescription)
                .ToListAsync();
        }
    }
}
