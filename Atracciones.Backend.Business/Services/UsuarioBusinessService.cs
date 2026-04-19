using Atracciones.Backend.Business.DTOs.Usuario;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.DataManagement.Interfaces;
using Microservicio.Clientes.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class UsuarioBusinessService : IUsuarioBusinessService
    {
        private readonly IUsuarioDataService _dataService;

        public UsuarioBusinessService(IUsuarioDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<UsuarioResponse> GetByIdAsync(int id)
        {
            var data = await _dataService.GetByIdAsync(id)
                ?? throw new NotFoundException("Usuario", id);

            return UsuarioBusinessMapper.ToResponse(data);
        }

        public async Task<int> CreateAsync(CreateUsuarioRequest request)
        {
            var model = UsuarioBusinessMapper.ToCreateModel(request);
            return await _dataService.CreateAsync(model);
        }

        public async Task UpdateAsync(UpdateUsuarioRequest request)
        {
            var model = UsuarioBusinessMapper.ToUpdateModel(request);
            await _dataService.UpdateAsync(model);
        }

        public async Task<UsuarioResponse> LoginAsync(LoginRequest request)
        {
            var data = await _dataService.LoginAsync(request.Login, request.Password);

            if (data == null)
                throw new UnauthorizedBusinessException("Credenciales inválidas");

            return UsuarioBusinessMapper.ToResponse(data);
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest request)
        {
            await _dataService.ChangePasswordAsync(
                request.UsuarioId,
                request.PasswordActual,
                request.PasswordNuevo);
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }
    }
}
