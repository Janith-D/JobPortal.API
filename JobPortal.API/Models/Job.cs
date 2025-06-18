using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace JobPortal.API.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public int EmployerId { get; set; }

        [ForeignKey("EmployerId")]
        public User? Employer { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string EmploymentType { get; set; } = "Full-time";
        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Active"; // Active, Inactive

        public ICollection<Application>? Applications { get; set; }
    }
}
