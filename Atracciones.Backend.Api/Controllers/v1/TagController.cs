using Asp.Versioning;
using Atracciones.Backend.Api.Models.Common;
using Atracciones.Backend.Business.DTOs.Idioma;
using Atracciones.Backend.Business.DTOs.Tag;
using Atracciones.Backend.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atracciones.Backend.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagBusinessService _service;

        public TagController(ITagBusinessService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<TagResponse>>.Ok(data));
        }
    }
}
