using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Resena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class ResenaDataService : IResenaDataService
    {
        private readonly IResenaQuery _query;
        private readonly IUnitOfWork _uow;

        public ResenaDataService(IResenaQuery query, IUnitOfWork uow)
        {
            _query = query;
            _uow = uow;
        }

        public async Task<List<ResenaModel>> GetByAtraccionAsync(int atraccionId)
        {
            var data = await _query.GetByAtraccionAsync(atraccionId);
            return data.Select(ResenaMapper.ToModel).ToList();
        }

        public async Task<int> CreateAsync(ResenaCreateModel model)
        {
            var entity = ResenaMapper.ToEntity(model);
            await _uow.ResenaRepository.CreateAsync(entity);
            return entity.ResenaId;
        }

        public async Task UpdateAsync(ResenaUpdateModel model)
        {
            var entity = await _uow.ResenaRepository.GetByIdAsync(model.Id)
                ?? throw new Exception("Reseña no encontrada");

            entity.ResenaCalificacion = model.Calificacion;
            entity.ResenaComentario = model.Comentario;

            await _uow.ResenaRepository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _uow.ResenaRepository.SoftDeleteAsync(id);
        }
    }
}
