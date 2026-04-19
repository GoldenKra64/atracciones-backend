using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Reserva
{
    public class DetalleReservaRequest
    {
        public int TicketId { get; set; }
        public int Cantidad { get; set; }
    }
}
