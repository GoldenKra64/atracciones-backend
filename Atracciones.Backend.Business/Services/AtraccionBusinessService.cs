using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Atracciones;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.Business.Validators;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class AtraccionBusinessService : IAtraccionBusinessService
    {
        private readonly IAtraccionDataService _dataService;

        public AtraccionBusinessService(IAtraccionDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<int> CreateAsync(CreateAtraccionRequest request)
        {
            AtraccionValidator.ValidateCreate(request);

            var model = AtraccionBusinessMapper.ToCreateModel(request);

            return await _dataService.CreateAsync(model);
        }

        public async Task UpdateAsync(UpdateAtraccionRequest request)
        {
            AtraccionValidator.ValidateUpdate(request);

            var model = AtraccionBusinessMapper.ToUpdateModel(request);

            await _dataService.UpdateAsync(model);
        }

        public async Task<AtraccionResponse> GetByIdAsync(int id)
        {
            var data = await _dataService.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("Atracción", id);

            return AtraccionBusinessMapper.ToResponse(data);
        }

        public async Task<PagedResponse<AtraccionResponse>> GetPagedAsync(
            int page,
            int size,
            string? search,
            int? destinoId,
            int? categoriaId)
        {
            var data = await _dataService.GetPagedAsync(page, size, search, destinoId, categoriaId);

            return CommonBusinessMapper.ToPagedResponse(
                data,
                AtraccionBusinessMapper.ToResponse
            );
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
