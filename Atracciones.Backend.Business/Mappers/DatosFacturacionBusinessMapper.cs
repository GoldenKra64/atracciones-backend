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
                Nombres = request.Nombres,
                Apellidos = request.Apellidos,
                Telefono = request.Telefono,
                Correo = request.Correo
            };
        }

        public static DatosFacturacionResponse ToResponse(DatosFacturacionModel model)
        {
            return new DatosFacturacionResponse
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Telefono = model.Telefono,
                Correo = model.Correo
            };
        }
    }
}
