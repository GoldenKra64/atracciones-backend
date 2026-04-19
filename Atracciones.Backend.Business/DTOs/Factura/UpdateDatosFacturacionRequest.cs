using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Factura
{
    public class UpdateDatosFacturacionRequest : DatosFacturacionRequest
    {
        public int Id { get; set; }
    }
}
