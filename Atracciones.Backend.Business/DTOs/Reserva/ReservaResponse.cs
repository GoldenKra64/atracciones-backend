using Atracciones.Backend.Business.DTOs.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Reserva
{
    public class ReservaResponse : BaseResponse
    {
        public int ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }

        public decimal Total { get; set; }

        public List<DetalleReservaResponse> Detalles { get; set; } = new();

        public FacturaResponse? Factura { get; set; }
    }
}
