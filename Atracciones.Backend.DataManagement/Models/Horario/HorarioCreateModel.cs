using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Horario
{
    public class HorarioCreateModel
    {
        public int TicketId { get; set; }
        public DateTime Fecha { get; set; }           // "yyyy-MM-dd"
        public TimeSpan HoraInicio { get; set; }      // "HH:mm"
        public TimeSpan? HoraFin { get; set; }        // "HH:mm"
        public int Cupos { get; set; }
    }
}
