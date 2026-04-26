using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.NoIncluye;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NoIncluyeController : ControllerBase
    {
        private readonly INoIncluyeBusinessService _service;

        public NoIncluyeController(INoIncluyeBusinessService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<NoIncluyeResponse>>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNoIncluyeRequest request)
        {
            var id = await _service.CreateAsync(request);
            return Ok(ApiResponse<int>.Ok(id, "No Incluye creado"));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateNoIncluyeRequest request)
        {
            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("OK", "No Incluye actualizado"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.LogicalDeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("OK", "No Incluye eliminado"));
        }
    }
}