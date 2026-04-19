using Atracciones.Backend.DataManagement.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IUsuarioDataService
    {
        Task<int> CreateAsync(UsuarioCreateModel model);

        Task UpdateAsync(UsuarioUpdateModel model);

        Task SoftDeleteAsync(int id);
    }
}
