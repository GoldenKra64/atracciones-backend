using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Factura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IFacturaDataService
    {
        Task<FacturaModel?> GetByReservaAsync(int reservaId);
        Task<DataPagedResult<FacturaModel?>> GetByClienteAsync(int cliId, int page, int size);
        Task<List<FacturaModel>> GetAllAsync();
    }
}
