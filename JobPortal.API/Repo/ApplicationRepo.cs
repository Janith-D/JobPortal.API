using JobPortal.API.Data;
using JobPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.API.Repo
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly ApplicationDbContext _context;
        public ApplicationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var app = await _context.Applications.FindAsync(id);
            if(app != null)
            {
                _context.Applications.Remove(app);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _context.Applications.Include(a => a.Job).Include(a => a.JobSeeker).ToListAsync();
        }

        public async Task<Application?> GetByIdAsync(int id)
        {
            return await _context.Applications.Include(a => a.Job).Include(a => a.JobSeeker).FirstOrDefaultAsync(a => a.ApplicationId == id);
        }

        public async Task UpdateAsync(Application application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
        }
    }
}
