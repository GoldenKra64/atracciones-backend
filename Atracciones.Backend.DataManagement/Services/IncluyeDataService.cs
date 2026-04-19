using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models;
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

        public async Task<List<IncluyeModel>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            return data.Select(CatalogosMapper.ToModel).ToList();
        }

        public async Task<int> CreateAsync(IncluyeModel model)
        {
            var entity = new Incluye
            {
                IncDescripcion = model.Descripcion,
                IncEstado = "ACT"
            };

            await _repo.CreateAsync(entity);
            return entity.IncId;
        }
    }
}
