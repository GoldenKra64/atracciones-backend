using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Horario;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class HorarioValidator
    {
        public static void ValidateCreate(CreateHorarioRequest request)
        {
            if (request.TicketId <= 0)
                throw new ValidationException("TicketId obligatorio");

            if (request.Cupos < 0)
                throw new ValidationException("Los cupos no pueden ser negativos");

            if (request.Fecha.Date < DateTime.UtcNow.Date)
                throw new ValidationException("La fecha no puede ser pasada");

            if (request.HoraFin.HasValue && request.HoraFin <= request.HoraInicio)
                throw new ValidationException("HoraFin debe ser mayor a HoraInicio");
        }

        public static void ValidateUpdate(UpdateHorarioRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            if (request.Cupos < 0)
                throw new ValidationException("Los cupos no pueden ser negativos");

            // 📅 Fecha
            if (!DateTime.TryParseExact(
                    request.Fecha,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var fecha))
            {
                throw new ValidationException("Formato de fecha inválido. Use yyyy-MM-dd");
            }

            if (fecha.Date < DateTime.UtcNow.Date)
                throw new ValidationException("La fecha no puede ser pasada");

            // ⏰ Hora inicio
            if (!TimeSpan.TryParseExact(
                    request.HoraInicio,
                    @"hh\:mm",
                    CultureInfo.InvariantCulture,
                    out var horaInicio))
            {
                throw new ValidationException("Formato de hora_inicio inválido. Use HH:mm");
            }

            // ⏰ Hora fin
            if (!string.IsNullOrEmpty(request.HoraFin))
            {
                if (!TimeSpan.TryParseExact(
                        request.HoraFin,
                        @"hh\:mm",
                        CultureInfo.InvariantCulture,
                        out var horaFin))
                {
                    throw new ValidationException("Formato de hora_fin inválido. Use HH:mm");
                }

                if (horaFin <= horaInicio)
                    throw new ValidationException("HoraFin debe ser mayor a HoraInicio");
            }
        }
    }
}
