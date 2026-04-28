using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Factura;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Models;
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

        public async Task<PagedResponse<FacturaResponse?>> GetByClienteAsync(int cliId, int page, int size)
        {
            var data = await _dataService.GetByClienteAsync(cliId, page, size);

            return CommonBusinessMapper.ToPagedResponse(
                data,
                FacturaBusinessMapper.ToResponse
            );
        }

        public async Task<FacturaResponse?> GetByReservaAsync(int reservaId)
        {
            var data = await _dataService.GetByReservaAsync(reservaId);

            return data == null
                ? null
                : FacturaBusinessMapper.ToResponse(data);
        }

        public async Task<List<FacturaResponse>> GetAllFacturasAsync()
        {
            var data = await _dataService.GetAllAsync();

            return data.Select(FacturaBusinessMapper.ToResponse).ToList();
        }
    }
}
