using Atracciones.Backend.Business.DTOs.Factura;
using Atracciones.Backend.DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class DatosFacturacionBusinessMapper
    {
        public static DatosFacturacionModel ToModel(DatosFacturacionRequest request)
        {
            return new DatosFacturacionModel
            {
                RazonSocial = request.RazonSocial,
                Ruc = request.Ruc,
                Direccion = request.Direccion
            };
        }

        public static DatosFacturacionResponse ToResponse(DatosFacturacionModel model)
        {
            return new DatosFacturacionResponse
            {
                RazonSocial = model.RazonSocial,
                Ruc = model.Ruc
            };
        }
    }
}
