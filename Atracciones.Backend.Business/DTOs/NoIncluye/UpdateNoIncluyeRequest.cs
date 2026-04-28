using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.NoIncluye
{
    public class UpdateNoIncluyeRequest : CreateNoIncluyeRequest
    {
        public int Id { get; set; }
    }
}