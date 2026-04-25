using Atracciones.Backend.DataManagement.Models.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Ticket
{
    public class TicketModel : BaseModel
    {
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public int HorarioId { get; set; }
        public HorarioModel Horario { get; set; }
    }
}
