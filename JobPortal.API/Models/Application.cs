using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.API.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        [ForeignKey("JobId")]
        [JsonIgnore]
        public Job? Job { get; set; }
        public int JobSeekerId { get; set; }
        [ForeignKey("JobSeekerId")]
        [JsonIgnore]
        public User? JobSeeker { get; set; }
        public string ResumeUrl { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
    }
}
