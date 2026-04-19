using Atracciones.Backend.DataAccess.Queries.Interfaces;
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
    public class IdiomaDataService : IIdiomaDataService
    {
        private readonly IIdiomaQuery _query;

        public IdiomaDataService(IIdiomaQuery query)
        {
            _query = query;
        }

        public async Task<List<IdiomaModel>> GetAllAsync()
        {
            var data = await _query.GetAllAsync();
            return data.Select(CatalogosMapper.ToModel).ToList();
        }
    }
}
