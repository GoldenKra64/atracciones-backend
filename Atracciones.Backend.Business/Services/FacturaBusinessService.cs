using Atracciones.Backend.Business.DTOs.Factura;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.DataManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class FacturaBusinessService : IFacturaBusinessService
    {
        private readonly IFacturaDataService _dataService;

        public FacturaBusinessService(IFacturaDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<FacturaResponse?> GetByReservaAsync(int reservaId)
        {
            var data = await _dataService.GetByReservaAsync(reservaId);

            return data == null
                ? null
                : FacturaBusinessMapper.ToResponse(data);
        }
    }
}
