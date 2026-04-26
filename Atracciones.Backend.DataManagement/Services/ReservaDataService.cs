using Atracciones.Backend.DataAccess.Entities;
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
            if (model == null) throw new ArgumentNullException(nameof(model));

            await _uow.BeginTransactionAsync();

            try
            {
                var entity = ReservaMapper.ToEntity(model);

                if (model.Lineas == null || !model.Lineas.Any())
                    throw new Exception("Debe incluir al menos un detalle en la reserva.");

                foreach (var linea in model.Lineas)
                {
                    if (linea.TicketId == null)
                        throw new Exception($"Ticket inválido en la línea (TicketId: {linea.TicketId}).");

                    var ticket = await _uow.TicketRepository.GetByIdAsync(linea.TicketId)
                        ?? throw new Exception($"Ticket {linea.TicketId} not found");

                    var det = new DetalleReserva
                    {
                        DetRevGuid = Guid.NewGuid().ToString(),
                        TicId = ticket.TicId,
                        TicTipoParticipante = ticket.TicTipoParticipante,
                        TicCantidad = linea.Cantidad,
                        TicPrecioUnitario = (double)ticket.TicPrecio,
                        TicSubtotal = (double)(ticket.TicPrecio * linea.Cantidad),
                        TicTitulo = ticket.TicTitulo
                    };

                    entity.Detalles.Add(det);
                }

                // Totals
                entity.RevSubtotal = entity.Detalles.Sum(x => x.TicSubtotal);
                entity.RevValorIva = 15;
                entity.RevTotal = (double)(entity.RevSubtotal * (1 + entity.RevValorIva / 100));

                var createdId = await _uow.ReservaRepository.CreateWithDetallesAsync(entity);

                await _uow.CommitAsync();

                return createdId;
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
