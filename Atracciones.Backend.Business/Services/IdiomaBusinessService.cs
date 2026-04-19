using Atracciones.Backend.Business.DTOs.Idioma;
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
    public class IdiomaBusinessService : IIdiomaBusinessService
    {
        private readonly IIdiomaDataService _dataService;

        public IdiomaBusinessService(IIdiomaDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<IdiomaResponse>> GetAllAsync()
        {
            var data = await _dataService.GetAllAsync();
            return data.Select(CatalogosBusinessMapper.ToResponse);
        }
    }
}
