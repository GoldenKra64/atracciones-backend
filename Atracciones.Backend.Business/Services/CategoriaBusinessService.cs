using Atracciones.Backend.Business.DTOs.Categoria;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class CategoriaBusinessService : ICategoriaBusinessService
    {
        private readonly ICategoriaDataService _dataService;

        public CategoriaBusinessService(ICategoriaDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<CategoriaResponse>> GetAllAsync()
        {
            var data = await _dataService.GetTreeAsync();
            return data.Select(CatalogosBusinessMapper.ToResponse);
        }
    }
}
