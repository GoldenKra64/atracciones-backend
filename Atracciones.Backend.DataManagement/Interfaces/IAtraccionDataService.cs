using Atracciones.Backend.Business.DTOs.Atraccion;
using Atracciones.Backend.DataAccess.Entities;
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

        Task<AtraccionModel?> GetByIdAsync(string id);
        Task<AtraccionModel?> GetInternalByIdAsync(string id);
        Task<List<AtraccionModel?>> GetAllInternalAsync();

        Task CreateAsync(AtraccionCreateModel model);

        Task UpdateAsync(AtraccionUpdateModel model);

        Task SoftDeleteAsync(string id);

        Task<List<AtraccionTypeModel?>> GetAtraccionTypeAsync();
    }
}
