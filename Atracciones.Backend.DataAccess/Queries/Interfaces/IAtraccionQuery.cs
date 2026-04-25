using Atracciones.Backend.DataAccess.Common;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Queries.Interfaces
{
    public interface IAtraccionQuery
    {
        Task<PagedResult<Atraccion>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? ciudad,
            string? idioma,
            string? ordenarPor,
            decimal? calificacionMin,
            string? horario,
            string? tipo,
            string? subTipo);

        Task<Atraccion?> GetByIdAsync(string id); // Guid
    }
}
