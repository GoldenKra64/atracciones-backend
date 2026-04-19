using Atracciones.Backend.Business.DTOs.Resena;
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
    public class ResenaBusinessService : IResenaBusinessService
    {
        private readonly IResenaDataService _dataService;

        public ResenaBusinessService(IResenaDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<ResenaResponse>> GetByAtraccionAsync(int atraccionId)
        {
            var data = await _dataService.GetByAtraccionAsync(atraccionId);
            return data.Select(ResenaBusinessMapper.ToResponse);
        }

        public async Task<int> CreateAsync(CreateResenaRequest request)
        {
            var model = ResenaBusinessMapper.ToCreateModel(request);
            return await _dataService.CreateAsync(model);
        }

        public async Task UpdateAsync(UpdateResenaRequest request)
        {
            var model = ResenaBusinessMapper.ToUpdateModel(request);
            await _dataService.UpdateAsync(model);
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
