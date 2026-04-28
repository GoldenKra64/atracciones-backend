using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Atraccion;
using Atracciones.Backend.DataManagement.Models.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class FacturaDataService : IFacturaDataService
    {
        private readonly IFacturaRepository _repo;
        private readonly IFacturaQuery _query;

        public FacturaDataService(IFacturaRepository repo, IFacturaQuery query)
        {
            _repo = repo;
            _query = query;
        }

        public async Task<DataPagedResult<FacturaModel?>> GetByClienteAsync(int cliId, int page, int size)
        {
            var data = await _query.GetAllByClienteAsync(cliId, page, size);

            return new DataPagedResult<FacturaModel>
            {
                Items = data.Items.Select(FacturaMapper.ToModel),
                TotalRecords = data.TotalRecords,
                PageNumber = data.PageNumber,
                PageSize = data.PageSize
            };
        }

        public async Task<FacturaModel?> GetByReservaAsync(int reservaId)
        {
            var data = await _repo.GetByReservaAsync(reservaId);
            return data == null ? null : FacturaMapper.ToModel(data);
        }

        public async Task<List<FacturaModel>> GetAllAsync()
        {
            var data = await _query.GetAllFacturasAsync();
            return data.Select(FacturaMapper.ToModel).ToList();
        }
    }
}
