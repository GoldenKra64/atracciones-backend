using Atracciones.Backend.DataManagement.Models.Factura;
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
    }
}
