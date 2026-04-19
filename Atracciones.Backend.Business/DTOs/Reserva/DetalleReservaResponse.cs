using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Reserva
{
    public class DetalleReservaResponse
    {
        public int TicketId { get; set; }
        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
