using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Reserva
{
    public class DetalleReservaResponse
    {
        public string TicketId { get; set; }
        public int Cantidad { get; set; }

        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
    }
}
