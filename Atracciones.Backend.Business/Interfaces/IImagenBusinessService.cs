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
        Task<int> CreateAsync(CreateImagenRequest request);

        Task LogicalDeleteAsync(int id);
    }
}
