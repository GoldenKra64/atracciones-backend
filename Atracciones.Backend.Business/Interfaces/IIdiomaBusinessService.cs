using Atracciones.Backend.Business.DTOs.Idioma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IIdiomaBusinessService
    {
        Task<IEnumerable<IdiomaResponse>> GetAllAsync();
    }
}
