namespace JobPortal.API.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "JobSeeker"; 
        public string? ProfileImageUrl { get; set; }
    }
}
