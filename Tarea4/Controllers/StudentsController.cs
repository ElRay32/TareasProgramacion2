using Microsoft.AspNetCore.Mvc;
using Tarea2Api.Contract;
using Tarea2Api.Dtos;

namespace Tarea2Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var result = await _service.GetAllAsync();
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(StudentDto dto)
        {
            var result = await _service.CreateAsync(dto);
            if (!result.Success) return BadRequest(result.Message);
            return CreatedAtAction(nameof(GetStudent), new { id = result.Data!.Id }, result.Data);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutStudent(int id, StudentDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return NoContent();
        }
    }
}
