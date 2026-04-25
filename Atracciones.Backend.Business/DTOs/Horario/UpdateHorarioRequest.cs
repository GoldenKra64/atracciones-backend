using Atracciones.Backend.Business.DTOs.Destino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Horario
{
    public class UpdateHorarioRequest
    {
        public int Id { get; set; }
        public int AtraccionId { get; set; }
        public string Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string? HoraFin { get; set; }
        public int Cupos { get; set; }

        public string Estado { get; set; } = null!;
    }
}
