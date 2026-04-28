using Atracciones.Backend.DataManagement.Models.Imagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IImagenDataService
    {
        Task<ImagenModel> GetByIdAsync(int id);
        Task<List<ImagenModel>> GetAllAsync();
        Task UpdateAsync(ImagenUpdateModel model);
        Task<int> CreateAsync(ImagenCreateModel model);
        Task SoftDeleteAsync(int id);
    }
}
