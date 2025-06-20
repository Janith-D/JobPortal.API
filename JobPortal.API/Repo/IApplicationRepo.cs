using JobPortal.API.Models;

namespace JobPortal.API.Repo
{
    public interface IApplicationRepo
    {
        Task<IEnumerable<Application>> GetAllAsync();
        Task<Application?> GetByIdAsync(int id);
        Task AddAsync(Application application);
        Task UpdateAsync(Application application);
        Task DeleteAsync(int id);
    }
}
