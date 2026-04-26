using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IReservaDataService
    {
        Task<ReservaModel> CreateAsync(ReservaCreateModel model);

        Task<ReservaModel?> GetByIdAsync(string id);

        Task<DataPagedResult<ReservaModel>> GetByClienteAsync(int clienteId, int page, int size);

        Task SoftDeleteAsync(int id);
    }
}
