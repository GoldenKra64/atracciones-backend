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
    public class ClienteQuery : IClienteQuery
    {
        private readonly AtraccionesDbContext _context;

        public ClienteQuery(AtraccionesDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(x => x.UsuId == usuarioId);
        }
    }
}
