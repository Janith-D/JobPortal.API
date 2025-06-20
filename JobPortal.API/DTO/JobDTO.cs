namespace JobPortal.API.DTO
{
    public class JobDTO
    {
        public int JobId { get; set; }
        public int EmployerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string EmploymentType { get; set; } = "Full-time";
        public string Status { get; set; } = "Active"; // Active, Inactive
    }
}
