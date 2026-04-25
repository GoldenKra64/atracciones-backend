using Atracciones.Backend.DataManagement.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface ITagDataService
    {
        Task<List<TagModel>> GetAllAsync();
    }
}
