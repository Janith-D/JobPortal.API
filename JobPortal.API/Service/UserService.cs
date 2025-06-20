using JobPortal.API.DTO;
using JobPortal.API.Models;
using JobPortal.API.Repo;

namespace JobPortal.API.Service
{
    public class UserService
    {
        private readonly IUserRepo _repo;
        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }
        public async Task AddUserAsync(UserDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                Role = dto.Role,
                ProfileImageUrl = dto.ProfileImageUrl
            };
            await _repo.AddAsync(user);
        }
        public async Task<IEnumerable<User>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<User?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task UpdateAsync(UserDTO dto)
        {
            var user = await _repo.GetByIdAsync(dto.UserId);
            if(user != null)
            {
                user.Username = dto.Username;
                user.Email = dto.Email;
                user.PasswordHash = dto.PasswordHash;
                user.Role = dto.Role;
                user.ProfileImageUrl = dto.ProfileImageUrl;
                await _repo.UpdateAsync(user);
            }
        }
        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
