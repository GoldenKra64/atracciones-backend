using Atracciones.Backend.DataManagement.Models.Destino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IDestinoDataService
    {
        Task<List<DestinoModel>> GetAllAsync();
        Task<DestinoModel> GetByIdAsync(int id);
        Task<int> CreateAsync(DestinoCreateModel model);

        Task UpdateAsync(DestinoUpdateModel model);

        Task SoftDeleteAsync(int id);
    }
}
