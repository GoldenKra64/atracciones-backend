using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Repositories
{
    public class IdiomaRepository : Repository<Idioma>
    {
        public IdiomaRepository(AtraccionesDbContext context) : base(context) { }

        public override async Task SoftDeleteAsync(int id)
        {
            throw new Exception("No se puede eliminar un idioma");
        }
    }
}
