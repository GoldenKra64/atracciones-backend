using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Exceptions
{
    public class ValidationException : BusinessException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(string message)
            : base(message, "VALIDATION_ERROR")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IDictionary<string, string[]> errors)
            : base("Uno o más errores de validación ocurrieron.", "VALIDATION_ERROR")
        {
            Errors = errors;
        }
    }
}
