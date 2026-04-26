using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Reserva;
using Atracciones.Backend.Business.Exceptions;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaBusinessService _service;

        public ReservaController(IReservaBusinessService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(ApiResponse<ReservaResponse>.Ok(data));
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(int clienteId, int page = 1, int size = 10)
        {
            var data = await _service.GetByClienteAsync(clienteId, page, size);
            return Ok(ApiResponse<PagedResponse<ReservaResponse>>.Ok(data));
        }

        [HttpPost]
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Create(CreateReservaRequest request)
        {
            var clienteId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (clienteId == null)
            {
                throw new UnauthorizedBusinessException("Cliente ID is missing");
            }

            request.ClienteId = int.Parse(clienteId);
            var response = await _service.CreateAsync(request);
            return Ok(ApiResponse<ReservaResponse>.Ok(response, "Reserva creada exitosamente", 201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.LogicalDeleteAsync(id);
            return Ok(ApiResponse<string>.Ok(null, "Reserva eliminada exitosamente", 204));
        }
    }
}
