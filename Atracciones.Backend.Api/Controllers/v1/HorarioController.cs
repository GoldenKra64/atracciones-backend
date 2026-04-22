using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Horario;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HorarioController : ControllerBase
    {
        private readonly IHorarioBusinessService _service;

        public HorarioController(IHorarioBusinessService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<HorarioDto>>.Ok(data));
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(CreateHorarioRequest request)
        {
            var id = await _service.CreateAsync(request);
            return Ok(ApiResponse<int>.Ok(id, "Horario creado"));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHorarioRequest request)
        {
            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("OK", "Horario actualizado"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.LogicalDeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("OK", "Horario eliminado"));
        }
    }
}
