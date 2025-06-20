namespace JobPortal.API.DTO
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public int JobSeekerId { get; set; }
        public string ResumeUrl { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
    }
}
