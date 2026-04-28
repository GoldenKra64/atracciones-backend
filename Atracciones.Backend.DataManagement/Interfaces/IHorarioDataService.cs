using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IHorarioDataService
    {
        Task<List<HorarioModel>> GetAllAsync();
        Task<HorarioModel> GetByIdAsync(string id);
        Task<int> CreateAsync(HorarioCreateModel model);

        Task UpdateAsync(HorarioUpdateModel model);

        Task SoftDeleteAsync(int id);
    }
}