using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Incluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class IncluyeDataService : IIncluyeDataService
    {
        private readonly IIncluyeRepository _repo;

        public IncluyeDataService(IIncluyeRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CreateAsync(IncluyeCreateModel model)
        {
            var entity = new Incluye
            {
                IncDescripcion = model.Descripcion,
                IncEstado = "ACT"
            };

            await _repo.CreateAsync(entity);
            return entity.IncId;
        }

        public async Task<IEnumerable<IncluyeModel>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(CatalogosMapper.ToModel).ToList();
        }
        public async Task UpdateAsync(IncluyeUpdateModel model)
        {
            var entity = await _repo.GetByIdAsync(model.Id)
                ?? throw new Exception("Incluye no encontrado");

            CatalogosMapper.UpdateEntity(entity, model);

            await _repo.UpdateAsync(entity);
        }
        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new Exception("Incluye no encontrado");

            entity.IncEstado = "INA";

            await _repo.UpdateAsync(entity);
        }

        public async Task<IncluyeModel> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            return CatalogosMapper.ToModel(data);
        }
    }
}
