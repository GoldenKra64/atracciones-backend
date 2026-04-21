using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Models.Imagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class ImagenDataService : IImagenDataService
    {
        private readonly IUnitOfWork _uow;

        public ImagenDataService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> CreateAsync(ImagenCreateModel model)
        {
            var entity = new Imagen
            {
                AtId = model.AtraccionId,
                ImgUrl = model.Url,
                ImgDescripcion = model.Descripcion,
                ImgEstado = "ACT",
                ImgFechaIngreso = DateTime.UtcNow,
                ImgIpIngreso = "127.0.1",
                ImgUsuarioIngreso = "system" // Solo es para pruebas
            };

            await _uow.ImagenRepository.CreateAsync(entity);
            return entity.ImgId;
        }

        public async Task SoftDeleteAsync(int id)
        {
            await _uow.ImagenRepository.SoftDeleteAsync(id);
        }
    }
}
