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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<List<ReservaResponse>>.Ok(data));
        }


        [HttpPost("cliente")]
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
            
            response = await _service.GetByIdAsync(response.rev_guid);

            return Ok(ApiResponse<ReservaResponse>.Ok(response, "Reserva creada y aprobada exitosamente", 201));
        }

        [HttpPost()]
        public async Task<IActionResult> CreatePublic(CreateReservaRequest request)
        {
            var response = await _service.CreatePublicAsync(request);
            return Ok(ApiResponse<ReservaResponse>.Ok(response, "Reserva y Factura creadas exitosamente", 201));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.LogicalDeleteAsync(id);
            return Ok(ApiResponse<string>.Ok(null, "Reserva eliminada exitosamente", 204));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(UpdateReservaRequest request, string id)
        {
            request.Id = id;
            var response = await _service.UpdateAsync(request);
            return Ok(ApiResponse<ReservaResponse>.Ok(response, "Reserva actualizada exitosamente", 200));
        }

        [HttpPost("{id:guid}/approve")]
        public async Task<IActionResult> Approve(string id)
        {
            await _service.ApproveAsync(id);
            return Ok(ApiResponse<string>.Ok(null, "Reserva y Factura generadas exitosamente", 200));
        }
    }
}
