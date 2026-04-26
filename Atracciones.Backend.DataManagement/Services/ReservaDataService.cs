using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Reserva;
using Microsoft.EntityFrameworkCore;
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
        private readonly IHorarioQuery horarioQuery;

        public ReservaDataService(IReservaQuery query, IUnitOfWork uow, IHorarioQuery horarioQuery)
        {
            _query = query;
            _uow = uow;
            this.horarioQuery = horarioQuery;
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

        public async Task<ReservaModel> CreateAsync(ReservaCreateModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            await _uow.BeginTransactionAsync();

            try
            {
                var horario = await horarioQuery.GetByGuidAsync(model.HorarioGuid);
                if (horario == null) throw new ArgumentNullException(nameof(horario));

                var entity = ReservaMapper.ToEntity(model, horario);
                foreach (var linea in model.Lineas)
                {
                    var ticket = await _uow.TicketRepository.GetByIdAsync(linea.TicketId);

                    var det = new DetalleReserva
                    {
                        DetRevGuid = Guid.NewGuid().ToString(),
                        TicId = ticket.TicId,
                        TicTipoParticipante = ticket.TicTipoParticipante,
                        TicCantidad = linea.Cantidad,
                        TicPrecioUnitario = (double)ticket.TicPrecio,
                        TicSubtotal = (double)(ticket.TicPrecio * linea.Cantidad),
                        TicTitulo = ticket.TicTitulo,
                        Ticket = ticket,
                        Reserva = entity,
                        RevId = entity.RevId
                    };

                    entity.Detalles.Add(det);
                }

                // Totals
                entity.RevSubtotal = entity.Detalles.Sum(x => x.TicSubtotal);
                entity.RevValorIva = (entity.RevSubtotal * 0.15);
                entity.RevTotal = (double)(entity.RevSubtotal + entity.RevValorIva);

                // FACTURAS
                var factura = new Factura()
                {
                    RevId = entity.RevId,
                    FacGuid = Guid.NewGuid().ToString(),
                    FacEstado = "ACT",
                    FacFechaEmision = DateTime.UtcNow,
                    FacIpIngreso = "127.0.0.1",
                    FacNumero = "2",
                    FacObservacion = "",
                    FacOrigenCanal = entity.RevCanal,
                    FacTotal = (decimal) entity.RevTotal,
                    FacUsuarioIngreso = "system",
                };

               var id = await _uow.ReservaRepository.CreateWithDetallesAsync(entity);
                factura.RevId = id;

                await _uow.FacturaRepository.CreateAsync(factura);

                await _uow.CommitAsync();

                return ReservaMapper.ToModel(entity);
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

        public async Task<ReservaModel?> GetByIdAsync(string id)
        {
            var entity = await _query.GetByIdAsync(id);
            return entity == null ? null : ReservaMapper.ToModel(entity);
        }
    }
}
