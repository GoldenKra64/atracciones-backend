using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Categoria;
using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Horario;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class HorarioMapper
    {
        public static HorarioModel ToModel(Horario entity)
        {
            return new HorarioModel
            {
                HorarioId = entity.HorId,
                HorarioGuid = entity.HorGuid,
                AtraccionId = entity.AtId,
                Fecha = entity.HorFecha.ToShortDateString(),
                HoraInicio = entity.HorHoraInicio.ToString(),
                HoraFin = entity.HorHoraFin?.ToString(),
                Cupos = entity.HorCuposDisponibles
            };
        }
        public static Horario ToEntity(HorarioModel model)
        {
            return new Horario
            {
                HorGuid = Guid.NewGuid().ToString(),
                HorEstado = "ACT",
                HorFecha = DateTime.ParseExact(model.Fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture),

                HorHoraInicio = TimeSpan.Parse(model.HoraInicio, CultureInfo.InvariantCulture),

                HorHoraFin = model.HoraFin != null
                    ? TimeSpan.Parse(model.HoraFin, CultureInfo.InvariantCulture)
                    : (TimeSpan?)null,

                HorCuposDisponibles = model.Cupos,

                AtId = model.AtraccionId
            };
        }
        public static void UpdateEntity(Horario entity, HorarioUpdateModel model)
        {
            entity.AtId = model.AtraccionId;
            entity.HorFecha = DateTime.ParseExact(model.Fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            entity.HorHoraInicio = TimeSpan.Parse(model.HoraInicio, CultureInfo.InvariantCulture);

            entity.HorHoraFin = model.HoraFin != null
                ? TimeSpan.Parse(model.HoraFin, CultureInfo.InvariantCulture)
                : (TimeSpan?)null;
            entity.HorCuposDisponibles = model.Cupos;
        }
    }
}
