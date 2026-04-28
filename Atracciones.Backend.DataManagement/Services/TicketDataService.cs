using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class TicketDataService : ITicketDataService
    {
        private readonly ITicketQuery _query;
        private readonly IUnitOfWork _uow;

        public TicketDataService(ITicketQuery query, IUnitOfWork uow)
        {
            _query = query;
            _uow = uow;
        }

        public async Task<int> CreateAsync(TicketCreateModel model)
        {
            var entity = TicketMapper.ToEntity(model);
            await _uow.TicketRepository.CreateAsync(entity);
            return entity.TicId;
        }

        public async Task UpdateAsync(TicketUpdateModel model)
        {
            var entity = await _uow.TicketRepository.GetByIdAsync(model.Id)
                ?? throw new Exception("Ticket no encontrado");

            TicketMapper.UpdateEntity(entity, model);

            await _uow.TicketRepository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _uow.TicketRepository.SoftDeleteAsync(id);
        }

        public async Task<List<TicketModel>> GetAllAsync()
        {
            var data = await _query.GetAllAsync();
            return data.Select(TicketMapper.ToModel).ToList();
        }

        public async Task<TicketModel> GetByIdAsync(int id)
        {
            var data = await _query.GetByIdAsync(id);
            return TicketMapper.ToModel(data);
        }
    }
}
