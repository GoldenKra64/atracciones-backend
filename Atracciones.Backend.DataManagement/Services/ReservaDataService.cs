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

        public async Task<ReservaModel> CreateAsync(ReservaCreateModel model, bool isPublic = false)
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

                if (!isPublic)
                {
                    entity.RevEstado = "APR";

                    var requiredSeatsByHorario = new Dictionary<int, int>();
                    var horariosToUpdate = new Dictionary<int, Horario>();

                    foreach (var det in entity.Detalles)
                    {
                        if (det.Ticket?.Horario != null)
                        {
                            var horId = det.Ticket.Horario.HorId;
                            if (!requiredSeatsByHorario.ContainsKey(horId))
                            {
                                requiredSeatsByHorario[horId] = 0;
                                horariosToUpdate[horId] = det.Ticket.Horario;
                            }
                            requiredSeatsByHorario[horId] += det.TicCantidad;
                        }
                    }

                    foreach (var kvp in requiredSeatsByHorario)
                    {
                        var requiredSeats = kvp.Value;
                        var horario_ = horariosToUpdate[kvp.Key];

                        if (horario_.HorCuposDisponibles < requiredSeats)
                        {
                            throw new Exception($"No hay suficientes cupos disponibles. Se requieren {requiredSeats} pero solo hay {horario_.HorCuposDisponibles} disponibles para este horario.");
                        }

                        horario_.HorCuposDisponibles -= requiredSeats;
                    }
                }
                
                var id = await _uow.ReservaRepository.CreateWithDetallesAsync(entity);

                if (!isPublic)
                {
                    var factura = new Factura()
                    {
                        RevId = id,
                        FacGuid = Guid.NewGuid().ToString(),
                        FacEstado = "ACT",
                        FacFechaEmision = DateTime.UtcNow,
                        FacIpIngreso = "127.0.0.1",
                        FacNumero = "2",
                        FacObservacion = "",
                        FacOrigenCanal = entity.RevCanal,
                        FacTotal = (decimal)entity.RevTotal,
                        FacUsuarioIngreso = "system",
                    };
                    await _uow.FacturaRepository.CreateAsync(factura);
                }

                await _uow.CommitAsync();

                return ReservaMapper.ToModel(entity);
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }

        public async Task SoftDeleteAsync(string reservaId)
        {
            await _uow.ReservaRepository.SoftDeleteAsync(reservaId);
        }

        public async Task ApproveAsync(string id)
        {
            await _uow.BeginTransactionAsync();
            try
            {
                var entity = await _query.GetByIdAsync(id);
                if (entity == null) throw new Exception("Reserva no encontrada");

                if (entity.RevEstado == "APR") 
                    throw new Exception("La reserva ya se encuentra aprobada.");

                var requiredSeatsByHorario = new Dictionary<int, int>();
                var horariosToUpdate = new Dictionary<int, Horario>();

                foreach (var det in entity.Detalles)
                {
                    if (det.Ticket?.Horario != null)
                    {
                        var horId = det.Ticket.Horario.HorId;
                        if (!requiredSeatsByHorario.ContainsKey(horId))
                        {
                            requiredSeatsByHorario[horId] = 0;
                            horariosToUpdate[horId] = det.Ticket.Horario;
                        }
                        requiredSeatsByHorario[horId] += det.TicCantidad;
                    }
                }

                foreach (var kvp in requiredSeatsByHorario)
                {
                    var requiredSeats = kvp.Value;
                    var horario = horariosToUpdate[kvp.Key];

                    if (horario.HorCuposDisponibles < requiredSeats)
                    {
                        throw new Exception($"No hay suficientes cupos disponibles. Se requieren {requiredSeats} pero solo hay {horario.HorCuposDisponibles} disponibles para este horario.");
                    }

                    horario.HorCuposDisponibles -= requiredSeats;
                }

                await _uow.ReservaRepository.ApproveAsync(id);

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
                    FacTotal = (decimal)entity.RevTotal,
                    FacUsuarioIngreso = "system",
                };

                await _uow.FacturaRepository.CreateAsync(factura);

                await _uow.CommitAsync();
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }

        public async Task<ReservaModel?> GetByIdAsync(string id)
        {
            var entity = await _query.GetByIdAsync(id);
            return entity == null ? null : ReservaMapper.ToModel(entity);
        }

        public async Task<List<ReservaModel?>> GetAllAsync()
        {
            var entity = await _query.GetAllAsync();
            return entity == null ? null : entity.Select(ReservaMapper.ToModel).ToList();
        }

        public async Task<ReservaModel?> UpdateAsync(UpdateReservaModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            await _uow.BeginTransactionAsync();

            try
            {
                var entity = await _query.GetByIdAsync(model.Id)
                    ?? throw new Exception("Reserva no encontrada");

                var horario = await horarioQuery.GetByGuidAsync(model.HorarioGuid);
                if (horario == null) throw new ArgumentNullException(nameof(horario));

                entity.CliId = model.ClienteId;
                entity.RevCanal = model.Canal;

                entity.HorFecha = horario.HorFecha.ToShortDateString();
                entity.HorHoraInicio = horario.HorHoraInicio.ToString();
                entity.HorHoraFin = horario.HorHoraFin?.ToString() ?? "";

                var detallesExistentes = entity.Detalles.ToDictionary(d => d.TicId);
                var detallesNuevos = new List<DetalleReserva>();

                foreach (var linea in model.Lineas)
                {
                    var ticket = await _uow.TicketRepository.GetByIdAsync(linea.TicketId);
                    if (ticket == null) throw new Exception($"Ticket {linea.TicketId} no encontrado");

                    if (detallesExistentes.TryGetValue(ticket.TicId, out var detExistente))
                    {
                        detExistente.TicCantidad = linea.Cantidad;
                        detExistente.TicPrecioUnitario = (double)ticket.TicPrecio;
                        detExistente.TicSubtotal = (double)(ticket.TicPrecio * linea.Cantidad);
                        detallesExistentes.Remove(ticket.TicId);
                    }
                    else
                    {
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
                        detallesNuevos.Add(det);
                    }
                }

                foreach (var d in detallesExistentes.Values)
                {
                    await _uow.ReservaRepository.DeleteDetalleAsync(d);
                    entity.Detalles.Remove(d);
                }

                foreach (var n in detallesNuevos)
                {
                    entity.Detalles.Add(n);
                }

                // Totals
                entity.RevSubtotal = entity.Detalles.Sum(x => x.TicSubtotal);
                entity.RevValorIva = (entity.RevSubtotal * 0.15);
                entity.RevTotal = (double)(entity.RevSubtotal + entity.RevValorIva);
                 
                var updatedEntity = await _uow.ReservaRepository.UpdateAsync(entity);

                await _uow.CommitAsync();

                return ReservaMapper.ToModel(updatedEntity);
            }
            catch
            {
                await _uow.RollbackAsync();
                throw;
            }
        }
    }
}
