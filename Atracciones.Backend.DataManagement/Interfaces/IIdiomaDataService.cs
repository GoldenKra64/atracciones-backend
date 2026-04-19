using Atracciones.Backend.DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IIdiomaDataService
    {
        Task<List<IdiomaModel>> GetAllAsync();
    }
}
