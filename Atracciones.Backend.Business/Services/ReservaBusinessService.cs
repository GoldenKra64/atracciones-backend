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
        private readonly ITicketDataService _ticketService;
        private readonly IHorarioDataService _horarioService;

        public ReservaBusinessService(IReservaDataService dataService, ITicketDataService ticketService, IHorarioDataService horarioService)
        {
            _dataService = dataService;
            _ticketService = ticketService;
            _horarioService = horarioService;
        }

        public async Task<ReservaResponse> CreateAsync(CreateReservaRequest request)
        {
            // ReservaValidator.ValidateCreate(request);

            if (request.Lineas == null || !request.Lineas.Any())
                throw new ValidationException("Debe incluir al menos un detalle en la reserva.");

            foreach (var linea in request.Lineas)
            {
                if (linea.tck_guid == null)
                    throw new ValidationException($"Ticket {linea.tck_guid} not found");
            }

            var model = ReservaBusinessMapper.ToCreateModel(request);

            var created = await _dataService.CreateAsync(model);

            return ReservaBusinessMapper.ToResponse(created);
        }

        public async Task<ReservaResponse> GetByIdAsync(string id)
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
