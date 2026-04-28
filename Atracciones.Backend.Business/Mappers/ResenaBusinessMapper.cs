using Atracciones.Backend.Business.DTOs.Resena;
using Atracciones.Backend.DataManagement.Models.Resena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class ResenaBusinessMapper
    {
        public static ResenaCreateModel ToCreateModel(CreateResenaRequest request)
        {
            return new ResenaCreateModel
            {
                ClienteId = request.ClienteId,
                AtraccionGuid = request.AtraccionGuid,
                Calificacion = request.Calificacion,
                Comentario = request.Comentario
            };
        }

        public static ResenaUpdateModel ToUpdateModel(UpdateResenaRequest request)
        {
            return new ResenaUpdateModel
            {
                Id = request.Id,
                Calificacion = request.Calificacion,
                Comentario = request.Comentario
            };
        }

        public static ResenaResponse ToResponse(ResenaModel model)
        {
            return new ResenaResponse
            {
                ClienteId = model.ClienteId,
                AtraccionId = model.AtraccionId,
                Calificacion = model.Calificacion,
                Comentario = model.Comentario,
                Fecha = DateTime.Parse(model.Fecha)
            };
        }
    }
}
