using Atracciones.Backend.Business.DTOs.Factura;
using Atracciones.Backend.DataManagement.Models.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class FacturaBusinessMapper
    {
        public static FacturaResponse ToResponse(FacturaModel model)
        {
            return new FacturaResponse
            {
                Id = model.Id,
                Guid = model.Guid,
                Estado = model.Estado,
                Total = model.Total,
                Observacion = model.Observacion,
                Numero = model.Numero,
                FechaEmision = model.FechaEmision,
                OrigenCanal = model.OrigenCanal
            };
        }
    }
}
