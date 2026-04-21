using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.Resena;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ResenaController : ControllerBase
    {
        private readonly IResenaBusinessService _service;

        public ResenaController(IResenaBusinessService service)
        {
            _service = service;
        }

        [HttpGet("atraccion/{id}")]
        public async Task<IActionResult> GetByAtraccion(int id)
        {
            var data = await _service.GetByAtraccionAsync(id);
            return Ok(ApiResponse<IEnumerable<ResenaResponse>>.Ok(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateResenaRequest request)
        {
            var id = await _service.CreateAsync(request);
            return Ok(ApiResponse<int>.Ok(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateResenaRequest request)
        {
            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("OK"));
        }
    }
}
