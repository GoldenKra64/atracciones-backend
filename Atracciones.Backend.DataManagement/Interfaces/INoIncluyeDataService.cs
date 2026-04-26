using Atracciones.Backend.DataManagement.Models.Incluye;
using Atracciones.Backend.DataManagement.Models.NoIncluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface INoIncluyeDataService
    {
        Task<int> CreateAsync(NoIncluyeCreateModel model);

        Task UpdateAsync(NoIncluyeUpdateModel model);

        Task<IEnumerable<NoIncluyeModel>> GetAllAsync();

        Task SoftDeleteAsync(int id);
    }
}
