using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Destino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class DestinoDataService : IDestinoDataService
    {
        private readonly IDestinoQuery _query;
        private readonly IUnitOfWork _uow;

        public DestinoDataService(IDestinoQuery query, IUnitOfWork uow)
        {
            _query = query;
            _uow = uow;
        }

        public async Task<List<DestinoModel>> GetAllAsync()
        {
            var data = await _query.GetAllAsync();
            return data.Select(CatalogosMapper.ToModel).ToList();
        }

        public async Task<int> CreateAsync(DestinoCreateModel model)
        {
            var entity = new Destino
            {
                DesNombre = model.Nombre,
                DesPais = model.Pais,
                DesImagenUrl = model.ImagenUrl,
                DesEstado = "ACT"
            };

            await _uow.DestinoRepository.CreateAsync(entity);
            return entity.DesId;
        }

        public async Task UpdateAsync(DestinoUpdateModel model)
        {
            var entity = await _uow.DestinoRepository.GetByIdAsync(model.Id)
                ?? throw new Exception("Destino no encontrado");

            CatalogosMapper.UpdateEntity(entity, model);

            await _uow.DestinoRepository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _uow.DestinoRepository.SoftDeleteAsync(id);
        }
    }
}
