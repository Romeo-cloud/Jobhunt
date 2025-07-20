namespace Jobhunt.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string FileName { get; set; } // Name of the resume file
        public string FilePath { get; set; } // Path to the resume file
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow; // Default to current date and time
    }
}
