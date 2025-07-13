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
        Task UpdateJobAsync(Job job);
        Task DeleteJobAsync(int id);
        Task<IEnumerable<Job>> SearchJobsAsync(string searchTerm);
        Task<IEnumerable<Job>> FilterJobsAsync(string WorkType,string location, int? categoryId);
    }
}
