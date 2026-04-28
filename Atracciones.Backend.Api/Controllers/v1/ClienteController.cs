using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.Cliente;
using Atracciones.Backend.Business.Exceptions;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBusinessService _service;

        public ClienteController(IClienteBusinessService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(ApiResponse<ClienteResponse>.Ok(data));
        }
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var id = User.Claims.FirstOrDefault(c => ClaimTypes.NameIdentifier == c.Type)?.Value;

            if (id == null)
            {
                throw new UnauthorizedBusinessException("Cliente ID is missing");
            }

            int cliId = int.Parse(id);

            var data = await _service.GetByIdAsync(cliId);
            return Ok(ApiResponse<ClienteResponse>.Ok(data));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ClienteResponse>>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClienteRequest request)
        {
            var id = await _service.CreateAsync(request);
            return Ok(ApiResponse<int>.Ok(id, "Cliente creado"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateClienteRequest request, int id)
        {
            request.Id = id;
            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("OK", "Cliente actualizado"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.LogicalDeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("OK", "Cliente eliminado"));
        }
    }
}
