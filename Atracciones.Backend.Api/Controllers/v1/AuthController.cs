using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.Usuario;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioBusinessService _service;

        public AuthController(IUsuarioBusinessService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var data = await _service.LoginAsync(request);

            if (data == null)
            {
                return Unauthorized(ApiErrorResponse.Fail("Credenciales inválidas"));
            }


            return Ok(ApiResponse<LoginResponse>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUsuarioRequest request)
        {
            var id = await _service.CreateAsync(request);
            return Ok(ApiResponse<int>.Ok(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUsuarioRequest request)
        {
            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("OK"));
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            await _service.ChangePasswordAsync(request);
            return Ok(ApiResponse<string>.Ok("OK"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.LogicalDeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("OK"));
        }
    }
}
