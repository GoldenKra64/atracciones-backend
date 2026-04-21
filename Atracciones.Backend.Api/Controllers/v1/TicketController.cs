using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.Ticket;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketBusinessService _service;

        public TicketController(ITicketBusinessService service)
        {
            _service = service;
        }

        [HttpGet("atraccion/{id}")]
        public async Task<IActionResult> GetByAtraccion(int id)
        {
            var data = await _service.GetByAtraccionAsync(id);
            return Ok(ApiResponse<IEnumerable<TicketResponse>>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketRequest request)
        {
            var id = await _service.CreateAsync(request);
            return Ok(ApiResponse<int>.Ok(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTicketRequest request)
        {
            await _service.UpdateAsync(request);
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
