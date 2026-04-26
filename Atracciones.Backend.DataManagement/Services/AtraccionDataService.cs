using Atracciones.Backend.Business.DTOs.Atraccion;
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
            // 201
        }

        public async Task UpdateAsync(AtraccionUpdateModel model)
        {
            var entity = await _uow.AtraccionRepository.GetByIdAsync(model.Id)
                ?? throw new Exception("Atracción no encontrada");

            AtraccionMapper.UpdateEntity(entity, model);

            await _uow.AtraccionRepository.UpdateAsync(entity);
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _uow.AtraccionRepository.SoftDeleteAsync(id);
        }
        /*
        public async Task<DataPagedResult<AtraccionModel>> SearchAsync(AtraccionFilterModel filter)
        {
            var data = await _query.SearchAsync(filter);

            return new DataPagedResult<AtraccionModel>
            {
                Items = data.Items.Select(AtraccionMapper.ToModel),
                TotalRecords = data.TotalRecords,
                PageNumber = data.PageNumber,
                PageSize = data.PageSize
            };
        }
        */
    }
}
