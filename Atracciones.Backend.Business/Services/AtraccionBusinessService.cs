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
using Atracciones.Backend.Business.DTOs.Atraccion;

namespace Atracciones.Backend.Business.Services
{
    public class AtraccionBusinessService : IAtraccionBusinessService
    {
        private readonly IAtraccionDataService _dataService;

        public AtraccionBusinessService(IAtraccionDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task CreateAsync(CreateAtraccionRequest request)
        {
            AtraccionValidator.ValidateCreate(request);

            var model = AtraccionBusinessMapper.ToCreateModel(request);

            await _dataService.CreateAsync(model);
        }

        public async Task UpdateAsync(UpdateAtraccionRequest request)
        {
            AtraccionValidator.ValidateUpdate(request);

            var model = AtraccionBusinessMapper.ToUpdateModel(request);

            await _dataService.UpdateAsync(model);
        }

        public async Task<AtraccionDetalleDto> GetByIdAsync(string id)
        {
            var data = await _dataService.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("Atracción", id);

            return AtraccionBusinessMapper.ToResponseDetalle(data);
        }

        public async Task<PagedResponse<ListadoAtracciones>> GetPagedAsync(
            FiltroDto filtro)
        {
            var filtroModel = AtraccionBusinessMapper.ToFilterModel(filtro);
            var data = await _dataService.GetPagedAsync(filtroModel);

            return CommonBusinessMapper.ToPagedResponse(
                data,
                AtraccionBusinessMapper.ToResponse
            );
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }

        public async Task<List<AtraccionTypeResponse>> GetAtraccionType()
        {
            var data = await _dataService.GetAtraccionTypeAsync();
            return data.Select(AtraccionBusinessMapper.ToModelType).ToList();
        }
    }
}
