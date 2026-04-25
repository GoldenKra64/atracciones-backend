using Atracciones.Backend.Business.DTOs.Atraccion;
using Atracciones.Backend.DataAccess.Filters;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Atraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IAtraccionDataService
    {
        Task<DataPagedResult<AtraccionModel>> GetPagedAsync(
            FiltroModel filtro);

        Task<AtraccionModel?> GetByIdAsync(int id);

        Task<int> CreateAsync(AtraccionCreateModel model);

        Task UpdateAsync(AtraccionUpdateModel model);

        Task SoftDeleteAsync(int id);

        Task<DataPagedResult<AtraccionModel>> SearchAsync(AtraccionFilterModel filter);
    }
}
