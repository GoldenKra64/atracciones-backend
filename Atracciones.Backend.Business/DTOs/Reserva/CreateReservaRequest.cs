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
        public int ClienteId { get; set; }

        public List<DetalleReservaRequest> Detalles { get; set; } = new();

        public DatosFacturacionRequest DatosFacturacion { get; set; } = null!;
    }
}
