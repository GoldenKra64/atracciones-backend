using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Reserva
{
    public class ReservaCreateModel
    {
        public int ClienteId { get; set; }

        public List<DetalleReservaModel> Detalles { get; set; } = new();

        public DatosFacturacionModel DatosFacturacion { get; set; } = null!;
    }
}
