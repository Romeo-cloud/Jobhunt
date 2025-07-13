namespace Jobhunt.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string WorkTyppe { get; set; } // e.g., Remote, On-site, Hybrid
        public string JobType { get; set; } // e.g., Full-time, Part-time, Contract
        public string CompanyName { get; set; }
        public string CompnayLogoUrl { get; set; } // URL to the company logo   
        public string SalaryRange { get; set; } // e.g., "$50,000 - $70,000"
        public DateTime PostedDate { get; set; }
        public int JobCategoryId { get; set; } // Foreign key to JobCategory
        public JobCategory JobCategory { get; set; } // Navigation property
    }
}
