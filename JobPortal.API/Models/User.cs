using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace JobPortal.API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "JobSeeker"; // Admin, Employer, JobSeeker
        public string? ProfileImageUrl { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public ICollection<Job>? Jobs { get; set; }
        [JsonIgnore]
        public ICollection<Application>? Applications { get; set; }
    }
}
