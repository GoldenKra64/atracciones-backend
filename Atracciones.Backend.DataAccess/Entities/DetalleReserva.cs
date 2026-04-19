using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class DetalleReserva
    {
        public int DetResId { get; set; }

        public int ResId { get; set; }
        public int TicId { get; set; }

        public int DetCantidad { get; set; }
        public decimal DetPrecioUnitario { get; set; }
        public decimal DetSubtotal { get; set; }

        // Navegación
        public Reserva Reserva { get; set; } = null!;
        public Ticket Ticket { get; set; } = null!;
    }
}
