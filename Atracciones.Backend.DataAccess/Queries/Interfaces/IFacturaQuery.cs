using Atracciones.Backend.DataAccess.Common;
using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries.Interfaces
{
    public interface IFacturaQuery
    {
        Task<PagedResult<Factura>> GetAllByClienteAsync(int cliId, int page, int size);
        Task<List<Factura>> GetAllFacturasAsync();
    }
}
