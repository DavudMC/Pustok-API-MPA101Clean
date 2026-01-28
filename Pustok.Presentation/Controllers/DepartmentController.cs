using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Business.Dtos;
using Pustok.Business.Services.Abstractions;
using Pustok.Core.Entities;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GelAll()
        {
            var departments = await _service.GetAllAsync();
            return Ok(departments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var department = await _service.GetByIdAsync(id);

            return Ok(department);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DepartmentCreateDto dto)
        {
            await _service.CreateAsync(dto);

            return Created();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] DepartmentUpdateDto dto)
        {
            await _service.UpdateAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
