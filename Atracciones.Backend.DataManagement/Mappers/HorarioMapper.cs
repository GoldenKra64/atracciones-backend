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
                Fecha = entity.HorFecha.ToString("yyyy-MM-dd"),
                HoraInicio = entity.HorHoraInicio.ToString("HH:mm"),
                HoraFin = entity.HorHoraFin?.ToString("HH:mm"),
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

                HorHoraInicio = TimeSpan.ParseExact(model.HoraInicio, @"hh\:mm", CultureInfo.InvariantCulture),

                HorHoraFin = string.IsNullOrEmpty(model.HoraFin)
                    ? (TimeSpan?)null
                    : TimeSpan.ParseExact(model.HoraFin, @"hh\:mm", CultureInfo.InvariantCulture),

                HorCuposDisponibles = model.Cupos,
            };
        }
        public static void UpdateEntity(Horario entity, HorarioUpdateModel model)
        {
            entity.TicId = model.TicketId;
            entity.HorFecha = DateTime.ParseExact(model.Fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            entity.HorHoraInicio = TimeSpan.ParseExact(model.HoraInicio, @"hh\:mm", CultureInfo.InvariantCulture);
            entity.HorHoraFin = string.IsNullOrEmpty(model.HoraFin)
                ? (TimeSpan?)null
                : TimeSpan.ParseExact(model.HoraFin, @"hh\:mm", CultureInfo.InvariantCulture);
            entity.HorCuposDisponibles = model.Cupos;
        }
    }
}
