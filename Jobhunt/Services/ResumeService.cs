using Jobhunt.Interfaces;
using Jobhunt.Models;
using Microsoft.AspNetCore.Http;
using Jobhunt.Context;

namespace Jobhunt.Services
{
    public class ResumeService : IResumeService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ResumeService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Resume> UploadResumeAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File cannot be null or empty.");
            var UploadPath = Path.Combine(_env.ContentRootPath, "Resumes Uploads", file.FileName);
           if (Directory.Exists(UploadPath) == false)
            {
                Directory.CreateDirectory(UploadPath);
            }
           var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
           var filePath = Path.Combine(UploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            var resume = new Resume
            {
                FileName = fileName,
                FilePath = filePath,
                UploadedAt = DateTime.UtcNow
            };
            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();
            return resume;
        }
        public async Task<IEnumerable<Resume>> GetAllResumesAsync()
        {
            return await Task.FromResult(_context.Resumes.ToList());
        }
        public async Task<Resume> GetResumeByIdAsync(int id)
        {
            return await _context.Resumes.FindAsync(id) ?? throw new KeyNotFoundException("Resume not found.");
        }
    }

    }