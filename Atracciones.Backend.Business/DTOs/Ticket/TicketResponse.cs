using Atracciones.Backend.Business.DTOs.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Ticket
{
    public class TicketResponse : BaseResponse
    {
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public HorarioDto Horario { get; set; } = null!;
    }
}
