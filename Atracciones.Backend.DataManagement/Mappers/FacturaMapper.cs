using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class FacturaMapper
    {
        public static FacturaModel ToModel(Factura entity)
        {
            return new FacturaModel
            {
                Id = entity.FacId,
                Guid = entity.FacGuid,
                Estado = entity.FacEstado,

                Numero = entity.FacNumero,
                FechaEmision = entity.FacFechaEmision,
                OrigenCanal = entity.FacOrigenCanal,
                Observacion = entity.FacObservacion
            };
        }
    }
}
