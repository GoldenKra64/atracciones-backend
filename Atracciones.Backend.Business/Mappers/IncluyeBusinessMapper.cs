using Atracciones.Backend.Business.DTOs.Incluye;
using Atracciones.Backend.DataManagement.Models.Incluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class IncluyeBusinessMapper
    {
        public static IncluyeCreateModel ToCreateModel(CreateIncluyeRequest request)
        {
            return new IncluyeCreateModel
            {
                Descripcion = request.Descripcion
            };
        }

        public static IncluyeUpdateModel ToUpdateModel(UpdateIncluyeRequest request)
        {
            return new IncluyeUpdateModel
            {
                Id = request.Id,
                Descripcion = request.Descripcion
            };
        }

        public static IncluyeResponse ToResponse(IncluyeModel model)
        {
            return new IncluyeResponse
            {
                Id = model.Id,
                Descripcion = model.Descripcion
            };
        }
    }
}
