using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class TagDataService : ITagDataService
    {
        private readonly ITagQuery _query;

        public TagDataService(ITagQuery query)
        {
            _query = query;
        }

        public async Task<List<TagModel>> GetAllAsync()
        {
            var data = await _query.GetAllAsync();
            return data.Select(CatalogosMapper.ToModel).ToList();
        }
    }
}
