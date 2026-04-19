using Atracciones.Backend.Business.DTOs.Imagen;
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
    public class ImagenBusinessService : IImagenBusinessService
    {
        private readonly IImagenDataService _dataService;

        public ImagenBusinessService(IImagenDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<int> CreateAsync(CreateImagenRequest request)
        {
            var model = ImagenBusinessMapper.ToCreateModel(request);
            return await _dataService.CreateAsync(model);
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
