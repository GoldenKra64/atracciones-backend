using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.DataManagement.Models.Destino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class DestinoBusinessMapper
    {
        public static DestinoCreateModel ToCreateModel(CreateDestinoRequest request)
        {
            return new DestinoCreateModel
            {
                Nombre = request.Nombre,
                Pais = request.Pais,
                ImagenUrl = request.ImagenUrl
            };
        }

        public static DestinoUpdateModel ToUpdateModel(UpdateDestinoRequest request)
        {
            return new DestinoUpdateModel
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Pais = request.Pais,
                ImagenUrl = request.ImagenUrl
            };
        }

        public static DestinoResponse ToResponse(DestinoModel model)
        {
            return new DestinoResponse
            {
                Id = model.Id,
                Guid = model.Guid,
                Nombre = model.Nombre,
                Pais = model.Pais
            };
        }
    }
}
