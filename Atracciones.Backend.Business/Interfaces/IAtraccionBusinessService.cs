using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Atraccion;
using Atracciones.Backend.Business.DTOs.Atracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IAtraccionBusinessService
    {
        Task<AtraccionResponse> GetByIdAsync(int id);

        Task<PagedResponse<AtraccionResponse>> GetPagedAsync(
            FiltroDto filtro);

        Task<int> CreateAsync(CreateAtraccionRequest request);

        Task UpdateAsync(UpdateAtraccionRequest request);

        Task LogicalDeleteAsync(int id);
    }
}
