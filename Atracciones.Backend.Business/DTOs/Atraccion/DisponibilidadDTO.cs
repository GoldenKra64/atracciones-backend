using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atraccion
{
    public class DisponibilidadDto
    {
        public bool Disponible { get; set; }
        public bool DisponibleHoy { get; set; }
        public DateTime? ProximaFechaDisponible { get; set; }
        public int? CuposDisponibles { get; set; }
    }
}
