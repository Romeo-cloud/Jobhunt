using Microsoft.EntityFrameworkCore;
using Jobhunt.Context;
using Jobhunt.Models;
using Jobhunt.Interfaces;

namespace Jobhunt.Services
{
    public class JobService :IJobServices
    {
        private readonly AppDbContext _context;
        public JobService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.Include(j => j.JobCategory).ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _context.Jobs.Include(j => j.JobCategory).FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<IEnumerable<Job>> GetJobsByCategoryAsync(int categoryId)
        {
            return await _context.Jobs.Include(j => j.JobCategory)
                .Where(j => j.JobCategoryId == categoryId)
                .ToListAsync();

        }
        public async Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync()
        {
            return await _context.JobCategories.ToListAsync();
        }

        public async Task CreateJobAsync(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
           
        }

        public async Task<Job> UpdateJobAsync(int id, Job job)
        {
            var existingJob = await _context.Jobs.FindAsync(id);
            if (existingJob == null)return null; // or throw an exception
            
            existingJob.Title = job.Title;
            existingJob.Description = job.Description;
            existingJob.Location = job.Location;
            existingJob.WorkTyppe = job.WorkTyppe;
            existingJob.JobType = job.JobType;
            existingJob.CompanyName = job.CompanyName;
            existingJob.CompnayLogoUrl = job.CompnayLogoUrl;
            existingJob.SalaryRange = job.SalaryRange;
            existingJob.PostedDate = job.PostedDate;
            existingJob.JobCategoryId = job.JobCategoryId;

            await _context.SaveChangesAsync();
            return existingJob;

        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return false;
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Job>> SearchJobsAsync(string searchTerm)
        {
            return await _context.Jobs.Include(j => j.JobCategory)
                .Where(j => j.Title.Contains(searchTerm) || j.Description.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task<IEnumerable<Job>> FilterJobsAsync(string workType, string location, int? categoryId)
        {
            var query = _context.Jobs.Include(j => j.JobCategory).AsQueryable();
            if (!string.IsNullOrEmpty(workType))
            {
                query = query.Where(j => j.WorkTyppe.ToLower() == workType.ToLower());
            }
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(j => j.Location.Contains(location));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(j => j.JobCategoryId == categoryId.Value);
            }
            return await query.ToListAsync();
        }

    }
}
