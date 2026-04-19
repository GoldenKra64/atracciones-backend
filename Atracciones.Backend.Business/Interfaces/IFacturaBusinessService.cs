using Atracciones.Backend.Business.DTOs.Factura;
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
    }
}
