using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Factura;
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
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaBusinessService _service;

        public FacturaController(IFacturaBusinessService service)
        {
            _service = service;
        }

        [HttpGet("reserva/{reservaId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetByReserva(int reservaId)
        {
            var data = await _service.GetByReservaAsync(reservaId);

            if (data == null)
                return NotFound(ApiErrorResponse.Fail("Factura no encontrada"));

            return Ok(ApiResponse<FacturaResponse>.Ok(data));
        }
        [HttpGet]
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> GetByClienteAsync([FromQuery] int page, [FromQuery] int size)
        {
            var clienteId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (clienteId == null)
            {
                throw new UnauthorizedBusinessException("Cliente ID is missing");
            }

            var clienteIdInt = int.Parse(clienteId);

            var data = await _service.GetByClienteAsync(clienteIdInt, page, size);

            if (data == null)
                return NotFound(ApiErrorResponse.Fail("Factura no encontrada"));

            return Ok(ApiResponse<PagedResponse<FacturaResponse>>.Ok(data));
        }

        [HttpGet("all")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _service.GetAllFacturasAsync();

            if (data == null)
                return NotFound(ApiErrorResponse.Fail("Facturas no encontradas"));

            return Ok(ApiResponse<List<FacturaResponse>>.Ok(data));
        }
    }
}