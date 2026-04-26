using Atracciones.Backend.Business.DTOs.Ticket;
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
    public class TicketBusinessService : ITicketBusinessService
    {
        private readonly ITicketDataService _dataService;

        public TicketBusinessService(ITicketDataService dataService)
        {
            _dataService = dataService;
        }

        /*
        public async Task<IEnumerable<TicketResponse>> GetByAtraccionAsync(int atraccionId)
        {
            var data = await _dataService.GetByAtraccionAsync(atraccionId);
            return data.Select(TicketBusinessMapper.ToResponse);
        }
        */

        public async Task<int> CreateAsync(CreateTicketRequest request)
        {
            var model = TicketBusinessMapper.ToCreateModel(request);
            return await _dataService.CreateAsync(model);
        }

        public async Task UpdateAsync(UpdateTicketRequest request)
        {
            var model = TicketBusinessMapper.ToUpdateModel(request);
            await _dataService.UpdateAsync(model);
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
