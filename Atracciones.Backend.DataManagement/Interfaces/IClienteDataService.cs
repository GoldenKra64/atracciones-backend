using Atracciones.Backend.DataManagement.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IClienteDataService
    {
        Task<ClienteModel?> GetByUsuarioAsync(int usuarioId);

        Task<int> CreateAsync(ClienteCreateModel model);

        Task UpdateAsync(ClienteUpdateModel model);

        Task SoftDeleteAsync(int id);
    }
}
