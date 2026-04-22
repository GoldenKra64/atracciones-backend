using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Horario;
using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class HorarioBusinessMapper
    {
        public static HorarioCreateModel ToCreateModel(CreateHorarioRequest request)
        {
            return new HorarioCreateModel
            {
                TicketId = request.TicketId,
                Fecha = request.Fecha,
                HoraInicio = request.HoraInicio,
                HoraFin = request.HoraFin,
                Cupos = request.Cupos
            };
        }

        public static HorarioUpdateModel ToUpdateModel(UpdateHorarioRequest request)
        {
            return new HorarioUpdateModel
            {
                Id = request.Id,
                TicketId = request.TicketId,
                Fecha = request.Fecha,
                HoraInicio = request.HoraInicio,
                HoraFin = request.HoraFin,
                Cupos = request.Cupos
            };
        }

        public static HorarioDto ToResponse(HorarioModel model)
        {
            return new HorarioDto
            {
                TicketId = model.TicketId,
                Fecha = model.Fecha,
                HoraInicio = model.HoraInicio,
                HoraFin = model.HoraFin,
                Cupos = model.Cupos
            };
        }
    }
}
