using Microsoft.AspNetCore.Http;
using Jobhunt.Models;
namespace Jobhunt.Interfaces
{
    public interface IResumeService
    {
        Task<Resume> UploadResumeAsync(IFormFile file);
        Task<IEnumerable<Resume>> GetAllResumesAsync();
        Task<Resume> GetResumeByIdAsync(int id);

    }
}

