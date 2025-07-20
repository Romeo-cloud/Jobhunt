using Jobhunt.Models;
namespace Jobhunt.Interfaces
{
    public interface IJobServices
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int id);
        Task<IEnumerable<Job>> GetJobsByCategoryAsync(int categoryId);
        Task<IEnumerable<JobCategory>> GetAllJobCategoriesAsync();
        Task CreateJobAsync(Job job);
        Task<Job> UpdateJobAsync(int id, Job job);
        Task<bool> DeleteJobAsync(int id);
        Task<IEnumerable<Job>> SearchJobsAsync(string searchTerm);
        Task<IEnumerable<Job>> FilterJobsAsync(string WorkType, string location, int? categoryId);
    }
}