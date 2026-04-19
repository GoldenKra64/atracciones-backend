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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AtraccionesDbContext context) : base(context) { }

        public async Task<bool> HasChildren(int id)
        {
            return await _context.Categorias.AnyAsync(x => x.CatParentId == id);
        }

        public override async Task SoftDeleteAsync(int id)
        {
            var hasChildren = await HasChildren(id);
            if (hasChildren)
                throw new Exception("No se puede eliminar una categoría con hijos");

            await base.SoftDeleteAsync(id);
        }
    }
}
