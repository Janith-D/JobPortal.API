using JobPortal.API.DTO;
using JobPortal.API.Models;
using JobPortal.API.Repo;

namespace JobPortal.API.Service
{
    public class JobService
    {
        private readonly IJobRepo _repo;
        public JobService(IJobRepo repo)
        {
            _repo = repo;
        }
        public async Task AddJobAsync(JobDTO dto)
        {
            var job = new Job
            {
                EmployerId = dto.EmployerId,
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Location = dto.Location,
                Salary = dto.Salary,
                EmploymentType = dto.EmploymentType,
                Status = dto.Status
            };
            await _repo.AddAsync(job);
        }
        public async Task<IEnumerable<JobDTO>> GetAllJobAsync()
        {
            var jobs = await _repo.GetAllAsync();
            return jobs.Select(j => new JobDTO
            {
                EmployerId = j.EmployerId,
                Title = j.Title,
                Description = j.Description,
                Category = j.Category,
                Location = j.Location,
                Salary = j.Salary,
                EmploymentType = j.EmploymentType,
                Status = j.Status,

            });
        }
        public async Task<JobDTO?> GetJobByIdAsync(int id)
        {
            var j = await _repo.GetByIdAsync(id);
            if (j == null) return null;
            return new JobDTO
            {
                EmployerId = j.EmployerId,
                Title = j.Title,
                Description = j.Description,
                Category = j.Category,
                Location = j.Location,
                Salary = j.Salary,
                EmploymentType = j.EmploymentType,
                Status = j.Status,
            };
        }
        public async Task UpdateJobAsync(JobDTO dto)
        {
            var job = await _repo.GetByIdAsync(dto.JobId);
            if (job != null)
            {
                job.EmployerId = dto.EmployerId;
                job.Title = dto.Title;
                job.Description = dto.Description;
                job.Category = dto.Category;
                job.Location = dto.Location;
                job.Salary = dto.Salary;
                job.EmploymentType = dto.EmploymentType;
                job.Status = dto.Status;
                await _repo.UpdateAsync(job);
            }
        }
        public async Task DeleteJobAsync(int id)
        {
            await _repo.DeleteAsync(id);

        }
    }
}
