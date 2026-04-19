using Atracciones.Backend.DataManagement.Models.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Reserva
{
    public class ReservaModel : BaseModel
    {
        public int ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }

        public decimal Total { get; set; }

        public List<DetalleReservaModel> Detalles { get; set; } = new();

        public FacturaModel? Factura { get; set; }
    }
}
