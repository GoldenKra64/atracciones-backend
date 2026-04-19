using Atracciones.Backend.Business.DTOs.Incluye;
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
    public class IncluyeBusinessService : IIncluyeBusinessService
    {
        private readonly IIncluyeDataService _dataService;

        public IncluyeBusinessService(IIncluyeDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<IncluyeResponse>> GetAllAsync()
        {
            var data = await _dataService.GetAllAsync();
            return data.Select(IncluyeBusinessMapper.ToResponse);
        }

        public async Task<int> CreateAsync(CreateIncluyeRequest request)
        {
            var model = IncluyeBusinessMapper.ToCreateModel(request);
            return await _dataService.CreateAsync(model);
        }

        public async Task UpdateAsync(UpdateIncluyeRequest request)
        {
            var model = IncluyeBusinessMapper.ToUpdateModel(request);
            await _dataService.UpdateAsync(model);
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
