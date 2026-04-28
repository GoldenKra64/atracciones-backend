using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Factura;
using Atracciones.Backend.DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IFacturaBusinessService
    {
        Task<FacturaResponse?> GetByReservaAsync(int reservaId);
        Task<PagedResponse<FacturaResponse?>> GetByClienteAsync(int cliId, int page, int size);
        Task<List<FacturaResponse>> GetAllFacturasAsync();
    }
}
