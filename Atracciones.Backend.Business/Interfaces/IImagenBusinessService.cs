using Atracciones.Backend.Business.DTOs.Imagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IImagenBusinessService
    {
        Task<List<ImagenResponse>> GetAllAsync();
        Task<ImagenResponse> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateImagenRequest request);
        Task UpdateAsync(UpdateImagenRequest request);
        Task LogicalDeleteAsync(int id);
    }
}
