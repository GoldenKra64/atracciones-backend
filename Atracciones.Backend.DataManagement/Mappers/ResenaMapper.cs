using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Resena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class ResenaMapper
    {
        public static ResenaModel ToModel(Resena entity)
        {
            return new ResenaModel
            {
                ClienteId = entity.CliId,
                AtraccionId = entity.AtId,
                Calificacion = entity.ResenaCalificacion,
                Comentario = entity.ResenaComentario,
                Fecha = entity.ResenaFechaCreacion
            };
        }

        public static Resena ToEntity(ResenaCreateModel model)
        {
            return new Resena
            {
                CliId = model.ClienteId,
                AtId = model.AtraccionId,
                ResenaCalificacion = model.Calificacion,
                ResenaComentario = model.Comentario,
                ResenaFechaCreacion = DateTime.UtcNow,
                ResenaEstado = "ACT"
            };
        }
    }
}
