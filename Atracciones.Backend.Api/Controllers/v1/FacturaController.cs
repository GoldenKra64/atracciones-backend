using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.Factura;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetByReserva(int reservaId)
        {
            var data = await _service.GetByReservaAsync(reservaId);

            if (data == null)
                return NotFound(ApiErrorResponse.Fail("Factura no encontrada"));

            return Ok(ApiResponse<FacturaResponse>.Ok(data));
        }
    }
}