using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pustok.Business.Dtos;
using Pustok.Business.Services.Abstractions;
using Pustok.Business.Services.Implementations;
using System.Threading.Tasks;

namespace Pustok.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GelAll()
        {
            var employees = await _service.GetAllAsync();
            return Ok(employees);   
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await _service.GetByIdAsync(id);

            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto dto)
        {
            await _service.CreateAsync(dto);

            return Created();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeeUpdateDto dto)
        {
            await _service.UpdateAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
