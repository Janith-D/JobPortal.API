using JobPortal.API.DTO;
using JobPortal.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _service;
        public ApplicationController(ApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var app = await _service.GetAllAsync();
            return Ok(app);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app == null) return NotFound("Application not Found");
            return Ok(app);
        }
        [HttpPost]
        public async Task<IActionResult> Create (ApplicationDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok("Apllication create Successfull");
        }
        [HttpPut]
        public async Task<IActionResult> Update(ApplicationDTO dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
