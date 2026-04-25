using Atracciones.Backend.Business.DTOs.Tag;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.DataManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class TagBusinessService : ITagBusinessService
    {
        private readonly ITagDataService _dataService;

        public TagBusinessService(ITagDataService dataService)
        {
            _dataService = dataService;
        }
        public async Task<IEnumerable<TagResponse>> GetAllAsync()
        {
            var data = await _dataService.GetAllAsync();
            return data.Select(CatalogosBusinessMapper.ToResponse);
        }
    }
}
