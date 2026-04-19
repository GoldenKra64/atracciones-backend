using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atracciones
{
    public class UpdateAtraccionRequest : CreateAtraccionRequest
    {
        public int Id { get; set; }
    }
}
