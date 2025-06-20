using JobPortal.API.DTO;
using JobPortal.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDTO dto)
        {
            await _service.AddUserAsync(dto);
            return Ok("User Created");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _service.GetAllAsync();
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserDTO dto)
        {
            await _service.UpdateAsync(dto);
            return Ok("User Update");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("User Deleted");

        }
    }
}
