using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Ticket
{
    public class TicketDto
    {
        public string TckGuid { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public string Moneda { get; set; } = "USD";
    }
}
