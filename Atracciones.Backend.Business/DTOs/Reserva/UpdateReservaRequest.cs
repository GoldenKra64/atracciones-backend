using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Reserva
{
    public class UpdateReservaRequest : CreateReservaRequest
    {
        public string? Id { get; set; }
    }
}
