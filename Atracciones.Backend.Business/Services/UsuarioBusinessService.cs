using Atracciones.Backend.Business.Common;
using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Usuario;
using Atracciones.Backend.Business.Exceptions;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.DataManagement.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class UsuarioBusinessService : IUsuarioBusinessService
    {
        private readonly IUsuarioDataService _dataService;
        private readonly JwtSettings _jwtSettings;

        public UsuarioBusinessService(IUsuarioDataService dataService, IOptions<JwtSettings> jwtOptions)
        {
            _dataService = dataService;
            _jwtSettings = jwtOptions.Value;
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

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var data = await _dataService.LoginAsync(request.Login, request.Password);

            if (data == null)
                throw new UnauthorizedBusinessException("Credenciales inválidas");

            var token = GenerateJwt.GenerateJwtToken(_jwtSettings, data.Login, data.Roles);

            return new LoginResponse
            {
                Success = true,
                Message = "Login exitoso",
                Token = token.Token,
                Expiration = token.Expiration,
                Username = data.Login,
                Roles = data.Roles
            };
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
