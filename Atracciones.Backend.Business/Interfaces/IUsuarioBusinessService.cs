using Atracciones.Backend.Business.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Interfaces
{
    public interface IUsuarioBusinessService
    {
        Task<UsuarioResponse> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateUsuarioRequest request);

        Task UpdateAsync(UpdateUsuarioRequest request);

        Task<UsuarioResponse> LoginAsync(LoginRequest request);

        Task ChangePasswordAsync(ChangePasswordRequest request);

        Task LogicalDeleteAsync(int id);
    }
}
