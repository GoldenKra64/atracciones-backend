using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Ticket
{
    public class UpdateTicketRequest : CreateTicketRequest
    {
        public int Id { get; set; }
    }
}
