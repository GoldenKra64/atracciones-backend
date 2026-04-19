using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservicio.Clientes.Business.Exceptions
{
    public class UnauthorizedBusinessException : BusinessException
    {
        public UnauthorizedBusinessException(string message)
            : base(message, "UNAUTHORIZED")
        {
        }
    }
}
