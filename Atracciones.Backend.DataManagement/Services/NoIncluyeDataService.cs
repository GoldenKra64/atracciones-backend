using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Incluye;
using Atracciones.Backend.DataManagement.Models.NoIncluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class NoIncluyeDataService : INoIncluyeDataService
    {
        private readonly INoIncluyeRepository _repo;

        public NoIncluyeDataService(INoIncluyeRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CreateAsync(NoIncluyeCreateModel model)
        {
            var entity = new NoIncluye
            {
                NoIncDescripcion = model.Descripcion,
                NoIncEstado = "ACT"
            };

            await _repo.CreateAsync(entity);
            return entity.NoIncId;
        }

        public async Task<IEnumerable<NoIncluyeModel>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(CatalogosMapper.ToModel).ToList();
        }
        public async Task UpdateAsync(NoIncluyeUpdateModel model)
        {
            var entity = await _repo.GetByIdAsync(model.Id)
                ?? throw new Exception("No Incluye no encontrado");

            CatalogosMapper.UpdateEntity(entity, model);

            await _repo.UpdateAsync(entity);
        }
        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new Exception("No Incluye no encontrado");

            entity.NoIncEstado = "INA";

            await _repo.UpdateAsync(entity);
        }

        public async Task<NoIncluyeModel> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            return CatalogosMapper.ToModel(data);
        }
    }
}
