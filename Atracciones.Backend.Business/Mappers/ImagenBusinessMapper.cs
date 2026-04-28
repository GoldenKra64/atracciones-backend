using Atracciones.Backend.Business.DTOs.Imagen;
using Atracciones.Backend.Business.DTOs.Incluye;
using Atracciones.Backend.DataManagement.Models.Imagen;
using Atracciones.Backend.DataManagement.Models.Incluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class ImagenBusinessMapper
    {
        public static ImagenCreateModel ToCreateModel(CreateImagenRequest request)
        {
            return new ImagenCreateModel
            {
                AtraccionId = request.AtraccionId,
                Descripcion = request.Descripcion,
                Url = request.Url,
            };
        }

        public static ImagenResponse ToResponse(ImagenModel model)
        {
            return new ImagenResponse
            {
                Id = model.Id,
                Url = model.Url,
                Descripcion = model.Descripcion,
                AtraccionId = model.AtraccionId
            };
        }

        public static ImagenUpdateModel ToUpdateModel(UpdateImagenRequest model)
        {
            return new ImagenUpdateModel
            {
                Id = model.Id,
                Url = model.Url,
                Descripcion = model.Descripcion,
                AtraccionId = model.AtraccionId
            };
        }
    }
}
