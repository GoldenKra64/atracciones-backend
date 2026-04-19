using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente> {
        Task<Cliente?> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
    }
}
