using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class CategoriaDataService : ICategoriaDataService
    {
        private readonly ICategoriaQuery _query;
        private readonly IUnitOfWork _uow;

        public CategoriaDataService(ICategoriaQuery query, IUnitOfWork uow)
        {
            _query = query;
            _uow = uow;
        }

        public async Task<List<CategoriaModel>> GetTreeAsync()
        {
            var data = await _query.GetTreeAsync();
            return data.Select(CatalogosMapper.ToModel).ToList();
        }

        public async Task<int> CreateAsync(CategoriaCreateModel model)
        {
            var entity = new Categoria
            {
                CatNombre = model.Nombre,
                CatParentId = model.ParentId,
                CatEstado = "ACT"
            };

            await _uow.CategoriaRepository.CreateAsync(entity);
            return entity.CatId;
        }

        public async Task UpdateAsync(CategoriaUpdateModel model)
        {
            var entity = await _uow.CategoriaRepository.GetByIdAsync(model.Id)
                ?? throw new Exception("Categoría no encontrada");

            CatalogosMapper.UpdateEntity(entity, model);

            await _uow.CategoriaRepository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _uow.CategoriaRepository.SoftDeleteAsync(id);
        }
    }
}
