using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
