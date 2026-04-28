using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Atraccion;
using Atracciones.Backend.Business.DTOs.Atracciones;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/atracciones")]
    public class AtraccionController : ControllerBase
    {
        private readonly IAtraccionBusinessService _service;

        public AtraccionController(IAtraccionBusinessService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(ApiResponse<AtraccionDetalleDto>.Ok(data, "Detalle de atracciones obtenido exitosamente"));
        }

        [HttpGet("type")]
        public async Task<IActionResult> GetType()
        {
            var data = await _service.GetAtraccionType();
            return Ok(ApiResponse<List<AtraccionTypeResponse>>.Ok(data, "Tipos de atracciones obtenidos exitosamente"));
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged(
            [FromQuery] FiltroDto? filtro)
        {
            var data = await _service.GetPagedAsync(filtro);
            return Ok(ApiResponse<PagedResponse<ListadoAtracciones>>.Ok(data, "Listado de atracciones obtenido exitosamente"));
        }   

        [HttpPost]
        public async Task<IActionResult> Create(CreateAtraccionRequest request)
        {
            await _service.CreateAsync(request);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAtraccionRequest request)
        {
            await _service.UpdateAsync(request);
            return Ok(ApiResponse<string>.Ok("OK"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.LogicalDeleteAsync(id);
            return Ok(ApiResponse<string>.Ok("OK"));
        }
    }
}
