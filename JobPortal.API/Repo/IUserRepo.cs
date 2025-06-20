using JobPortal.API.Models;

namespace JobPortal.API.Repo
{
    public interface IUserRepo
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
