using Atracciones.Backend.Business.DTOs.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Reserva
{
    public class CreateReservaRequest
    {
        public int? ClienteId { get; set; }
        public string hor_guid { get; set; } = null!;
        public string origen_canal { get; set; } = null!;
        public List<DetalleReservaRequest> Lineas { get; set; } = new();
    }
}
