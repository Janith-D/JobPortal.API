using JobPortal.API.DTO;
using JobPortal.API.Models;
using JobPortal.API.Repo;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobPortal.API.Service
{
    public class ApplicationService
    {
        private readonly IApplicationRepo _repo;
        public ApplicationService(IApplicationRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ApplicationDTO>> GetAllAsync()
        {
            var app = await _repo.GetAllAsync();
            return app.Select(a => new ApplicationDTO
            {
                ApplicationId = a.ApplicationId,
                JobId = a.JobId,
                JobSeekerId = a.JobSeekerId,
                ResumeUrl = a.ResumeUrl,
                Status = a.Status
            });
        }
        public async Task<ApplicationDTO?> GetByIdAsync(int id)
        {
            var a = await _repo.GetByIdAsync(id);
            if (a == null) return null;
            return new ApplicationDTO
            {
                ApplicationId = a.ApplicationId,
                JobId = a.JobId,
                JobSeekerId = a.JobSeekerId,
                ResumeUrl = a.ResumeUrl,
                Status = a.Status
            };
        }
        public async Task AddAsync(ApplicationDTO dto)
        {
            var app = new Application
            {
                ApplicationId = dto.ApplicationId,
                JobId = dto.JobId,
                JobSeekerId = dto.JobSeekerId,
                ResumeUrl = dto.ResumeUrl,
                Status = dto.Status
            };
            await _repo.AddAsync(app);
        }
        public async Task UpdateAsync(ApplicationDTO dto)
        {
            var app = await _repo.GetByIdAsync(dto.ApplicationId);
            if(app != null)
            {
                app.ResumeUrl = dto.ResumeUrl;
                app.Status = dto.Status;
                await _repo.UpdateAsync(app);
            }
        }
        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
