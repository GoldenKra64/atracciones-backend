using Atracciones.Backend.DataManagement.Models.Resena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IResenaDataService
    {
        Task<List<ResenaModel>> GetByAtraccionAsync(int atraccionId);

        Task<int> CreateAsync(ResenaCreateModel model);

        Task UpdateAsync(ResenaUpdateModel model);

        Task SoftDeleteAsync(int id);
    }
}
