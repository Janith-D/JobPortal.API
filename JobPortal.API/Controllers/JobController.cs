using JobPortal.API.DTO;
using JobPortal.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly JobService _service;
        public JobController(JobService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobDTO jobDto)
        {
            await _service.AddJobAsync(jobDto);
            return Ok("Job created successfully.");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _service.GetAllJobAsync();
            return Ok(jobs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _service.GetJobByIdAsync(id);
            if (job == null) return NotFound("Job not found.");
            return Ok(job);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] JobDTO jobDto)
        {
            await _service.UpdateJobAsync(jobDto);
            return Ok("Job updated successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteJobAsync(id);
            return Ok("Job deleted successfully.");
        }
    }
}
