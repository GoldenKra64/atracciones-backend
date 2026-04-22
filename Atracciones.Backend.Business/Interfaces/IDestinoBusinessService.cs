using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IDestinoBusinessService
    {
        Task<IEnumerable<DestinoResponse>> GetAllAsync();

        Task<int> CreateAsync(CreateDestinoRequest request);

        Task UpdateAsync(UpdateDestinoRequest request);

        Task LogicalDeleteAsync(int id);
    }
}
