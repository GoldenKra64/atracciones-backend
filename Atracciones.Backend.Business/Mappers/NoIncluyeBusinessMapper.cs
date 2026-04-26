using Atracciones.Backend.Business.DTOs.Incluye;
using Atracciones.Backend.Business.DTOs.NoIncluye;
using Atracciones.Backend.DataManagement.Models.Incluye;
using Atracciones.Backend.DataManagement.Models.NoIncluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class NoIncluyeBusinessMapper
    {
        public static NoIncluyeCreateModel ToCreateModel(CreateNoIncluyeRequest request)
        {
            return new NoIncluyeCreateModel
            {
                Descripcion = request.Descripcion
            };
        }

        public static NoIncluyeUpdateModel ToUpdateModel(UpdateNoIncluyeRequest request)
        {
            return new NoIncluyeUpdateModel
            {
                Id = request.Id,
                Descripcion = request.Descripcion
            };
        }

        public static NoIncluyeResponse ToResponse(NoIncluyeModel model)
        {
            return new NoIncluyeResponse
            {
                Id = model.Id,
                Descripcion = model.Descripcion
            };
        }
    }
}
