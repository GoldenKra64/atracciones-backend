using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private readonly AtraccionesDbContext _context;

        public UsuarioQuery(AtraccionesDbContext context)
        {
            _context = context;
        }
        public async Task<bool> UserIsAlreadyRegistered(string login)
        {
            var check = await _context.Usuarios.Where(c => c.UsuLogin == login).FirstOrDefaultAsync();

            return check != null;
        }
    }
}
