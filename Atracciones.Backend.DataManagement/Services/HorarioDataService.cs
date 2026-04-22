using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class HorarioDataService : IHorarioDataService
    {
        private readonly IHorarioQuery _query;
        private readonly IUnitOfWork _uow;

        public HorarioDataService(IHorarioQuery query, IUnitOfWork uow)
        {
            _query = query;
            _uow = uow;
        }

        public async Task<List<HorarioModel>> GetAllAsync()
        {
            var data = await _query.GetAllAsync();
            return data.Select(HorarioMapper.ToModel).ToList();
        }

        public async Task<int> CreateAsync(HorarioCreateModel model)
        {
            var entity = new Horario
            {
                HorGuid = Guid.NewGuid().ToString(),
                TicId = model.TicketId,
                HorFecha = model.Fecha,
                HorHoraInicio = model.HoraInicio,
                HorHoraFin = model.HoraFin,
                HorCuposDisponibles = model.Cupos,
                HorEstado = "ACT",
                HorFechaIngreso = DateTime.UtcNow,
                HorUsuarioIngreso = "system",
                HorIpIngreso = "127.0.0.1"
            };

            await _uow.HorarioRepository.CreateAsync(entity);
            return entity.HorId;
        }

        public async Task UpdateAsync(HorarioUpdateModel model)
        {
            var entity = await _uow.HorarioRepository.GetByIdAsync(model.Id)
                ?? throw new Exception("Horario no encontrado");

            HorarioMapper.UpdateEntity(entity, model);

            await _uow.HorarioRepository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _uow.DestinoRepository.SoftDeleteAsync(id);
        }
    }
}
