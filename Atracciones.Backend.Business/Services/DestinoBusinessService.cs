using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.DataManagement.Interfaces;
using Microservicio.Clientes.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class DestinoBusinessService : IDestinoBusinessService
    {
        private readonly IDestinoDataService _dataService;

        public DestinoBusinessService(IDestinoDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<DestinoResponse>> GetAllAsync()
        {
            var data = await _dataService.GetAllAsync();
            return data.Select(DestinoBusinessMapper.ToResponse);
        }

        public async Task<int> CreateAsync(CreateDestinoRequest request)
        {
            var model = DestinoBusinessMapper.ToCreateModel(request);
            return await _dataService.CreateAsync(model);
        }

        public async Task UpdateAsync(UpdateDestinoRequest request)
        {
            var model = DestinoBusinessMapper.ToUpdateModel(request);
            await _dataService.UpdateAsync(model);
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
