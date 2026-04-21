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
                Numero = model.Numero,
                FechaEmision = model.FechaEmision,
                OrigenCanal = model.OrigenCanal,

                DatosFacturacion = new DatosFacturacionResponse
                {
                    Nombres = model.DatosFacturacion.Nombres,
                    Apellidos = model.DatosFacturacion.Apellidos,
                    Telefono = model.DatosFacturacion.Telefono,
                    Correo = model.DatosFacturacion.Correo
                }
            };
        }
    }
}
