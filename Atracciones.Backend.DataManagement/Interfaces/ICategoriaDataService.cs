using Atracciones.Backend.DataManagement.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface ICategoriaDataService
    {
        Task<List<CategoriaModel>> GetTreeAsync();

        Task<int> CreateAsync(CategoriaCreateModel model);

        Task UpdateAsync(CategoriaUpdateModel model);

        Task SoftDeleteAsync(int id);
    }
}
