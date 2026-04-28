using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Horario;
using Atracciones.Backend.DataManagement.Models.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IHorarioBusinessService
    {
        Task<IEnumerable<HorarioDto>> GetAllAsync();
        Task<HorarioDto> GetByIdAsync(string id);
        Task<int> CreateAsync(CreateHorarioRequest request);
        Task UpdateAsync(UpdateHorarioRequest request);
        Task LogicalDeleteAsync(int id);
    }
}
