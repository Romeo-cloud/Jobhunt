using Jobhunt.Models;
using Microsoft.EntityFrameworkCore;
namespace Jobhunt.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Job>Jobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobCategory>().HasData(
                 new JobCategory { Id = 1, Name = "Accounting & Finance" },
                new JobCategory { Id = 2, Name = "Business Support" },
                new JobCategory { Id = 3, Name = "Data Science & Analytics" },
                new JobCategory { Id = 4, Name = "Design, Copy & Production" },
                new JobCategory { Id = 5, Name = "Education" },
                new JobCategory { Id = 6, Name = "Financial Services - Front Office" },
                new JobCategory { Id = 7, Name = "Financial Services - Operations" },
                new JobCategory { Id = 8, Name = "General Management" },
                new JobCategory { Id = 9, Name = "Healthcare & Lifesciences" },
                new JobCategory { Id = 10, Name = "Human Resources" },
                new JobCategory { Id = 11, Name = "Industrial" },
                new JobCategory { Id = 12, Name = "Legal" },
                new JobCategory { Id = 13, Name = "Marketing" },
                new JobCategory { Id = 14, Name = "Other" },
                new JobCategory { Id = 15, Name = "Procurement, Supply Chain & Logistics" },
                new JobCategory { Id = 16, Name = "Real Estate" },
                new JobCategory { Id = 17, Name = "Retail" },
                new JobCategory { Id = 18, Name = "Retail Banking" },
                new JobCategory { Id = 19, Name = "Risk & Compliance" },
                new JobCategory { Id = 20, Name = "Sales" },
                new JobCategory { Id = 21, Name = "Technology" }
                );
        }
        public DbSet<Resume> Resumes { get; set; }

    }
}
