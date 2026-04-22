using Atracciones.Backend.DataAccess.Common;
using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries.Interfaces
{
    public interface IAtraccionPublicQuery
    {
        // Task<PagedResult<Atraccion>> GetListadoAsync(FiltroDto filtro);
        Task<Atraccion?> GetDetalleAsync(Guid guid);
        Task<Atraccion> GetFiltrosAsync(string ciudad);
    }
}
