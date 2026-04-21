using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Reserva;
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
    public class ReservaBusinessService : IReservaBusinessService
    {
        private readonly IReservaDataService _dataService;

        public ReservaBusinessService(IReservaDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<int> CreateAsync(CreateReservaRequest request)
        {
            ReservaValidator.ValidateCreate(request);

            var model = ReservaBusinessMapper.ToCreateModel(request);

            return await _dataService.CreateAsync(model);
        }

        public async Task<ReservaResponse> GetByIdAsync(int id)
        {
            var data = await _dataService.GetByIdAsync(id);

            if (data == null)
                throw new NotFoundException("Reserva", id);

            return ReservaBusinessMapper.ToResponse(data);
        }

        public async Task<PagedResponse<ReservaResponse>> GetByClienteAsync(
            int clienteId,
            int page,
            int size)
        {
            var data = await _dataService.GetByClienteAsync(clienteId, page, size);

            return CommonBusinessMapper.ToPagedResponse(
                data,
                ReservaBusinessMapper.ToResponse
            );
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
