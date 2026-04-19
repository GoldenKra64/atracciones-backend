using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class ReservaDataService : IReservaDataService
    {
        private readonly IReservaQuery _query;
        private readonly IUnitOfWork _uow;

        public ReservaDataService(IReservaQuery query, IUnitOfWork uow)
        {
            _query = query;
            _uow = uow;
        }

        public async Task<DataPagedResult<ReservaModel>> GetByClienteAsync(int clienteId, int page, int size)
        {
            var result = await _query.GetByClienteAsync(clienteId, page, size);

            return new DataPagedResult<ReservaModel>
            {
                Items = result.Items.Select(ReservaMapper.ToModel),
                TotalRecords = result.TotalRecords,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public async Task<ReservaModel?> GetDetalleAsync(int reservaId)
        {
            var entity = await _query.GetDetalleAsync(reservaId);
            return entity == null ? null : ReservaMapper.ToModel(entity);
        }

        public async Task<int> CreateAsync(ReservaCreateModel model)
        {
            await _uow.BeginTransactionAsync();

            try
            {
                var entity = ReservaMapper.ToEntity(model);

                // 💥 Aquí luego puedes calcular total en Business
                entity.ResTotal = entity.Detalles.Sum(x => x.DetSubtotal);

                await _uow.ReservaRepository.CreateAsync(entity);

                await _uow.CommitAsync();

                return entity.ResId;
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }

        public async Task SoftDeleteAsync(int reservaId)
        {
            await _uow.ReservaRepository.SoftDeleteAsync(reservaId);
        }

        public async Task<ReservaModel?> GetByIdAsync(int id)
        {
            var entity = await _uow.ReservaRepository.GetByIdAsync(id);
            return entity == null ? null : ReservaMapper.ToModel(entity);
        }
    }
}
