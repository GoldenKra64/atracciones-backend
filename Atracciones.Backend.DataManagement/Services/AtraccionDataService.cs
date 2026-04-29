using Atracciones.Backend.Business.DTOs.Atraccion;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Filters;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Atraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class AtraccionDataService : IAtraccionDataService
    {
        private readonly IAtraccionQuery _query;
        private readonly IUnitOfWork _uow;

        public AtraccionDataService(IAtraccionQuery query, IUnitOfWork uow)
        {
            _query = query;
            _uow = uow;
        }

        public async Task<DataPagedResult<AtraccionModel>> GetPagedAsync(
            FiltroModel filtro)
        {
            var result = await _query.GetPagedAsync(filtro.Page, filtro.Limit, filtro.Ciudad,
                filtro.Idioma, filtro.OrdenarPor, filtro.CalificacionMin, filtro.Horario, filtro.Tipo, filtro.Subtipo);

            return new DataPagedResult<AtraccionModel>
            {
                Items = result.Items.Select(AtraccionMapper.ToModel),
                TotalRecords = result.TotalRecords,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }

        public async Task<AtraccionModel?> GetByIdAsync(string id)
        {
            var entity = await _query.GetByIdAsync(id);
            return entity == null ? null : AtraccionMapper.ToModel(entity);
        }

        public async Task CreateAsync(AtraccionCreateModel model)
        {
            var entity = AtraccionMapper.ToEntity(model);

            await _uow.AtraccionRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(AtraccionUpdateModel model)
        {
            var entity = await _query.GetInternalByIdAsync(model.Id)
                ?? throw new Exception("Atracción no encontrada");

            AtraccionMapper.UpdateEntity(entity, model);

            await _uow.AtraccionRepository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(string id)
        {
            await _uow.AtraccionRepository.SoftDeleteAsync(id);
        }

        public async Task<List<AtraccionTypeModel?>> GetAtraccionTypeAsync()
        {
            var model = await _query.GetAtraccionTypeAsync();
            return model.Select(AtraccionMapper.ToTypeModel).ToList();
        }

        public async Task<AtraccionModel> GetInternalByIdAsync(string id)
        {
            var model = await _query.GetInternalByIdAsync(id);
            return AtraccionMapper.ToModel(model);
        }

        public async Task<List<AtraccionModel?>> GetAllInternalAsync()
        {
            var model = await _query.GetAllInternalAsync();
            return model.Select(AtraccionMapper.ToModel).ToList();
        }
    }
}
