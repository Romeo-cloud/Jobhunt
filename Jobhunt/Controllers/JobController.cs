using Jobhunt.Interfaces;
using Jobhunt.Models;
using Microsoft.AspNetCore.Mvc;


namespace Jobhunt.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class JobController:ControllerBase
        {
            private readonly IJobServices _jobServices;
            public JobController(IJobServices jobServices)
            {
                _jobServices = jobServices;
            }

            [HttpGet]
            public async Task<IActionResult> GetJob() => Ok(await _jobServices.GetAllJobsAsync());

            [HttpGet]
            public async Task<IActionResult> GetJob(int id)
            {
                var job = await _jobServices.GetJobByIdAsync(id);
                return job == null ? NotFound(): Ok(job);
            }

            
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateJob(int id, Job job)
            {
                var updated = await _jobServices.UpdateJobAsync(id, job);
                return updated == null ? NotFound() : Ok(updated);
                
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteJob(int id)
            {
                var result = await _jobServices.DeleteJobAsync(id);
                return result ? NoContent() : NotFound();
            }
            [HttpGet("filter")]
            public async Task<IActionResult> FilterJobs([FromQuery] string workType,[FromQuery] string location, [FromQuery] int? categoryId)
            {
                var jobs = await _jobServices.FilterJobsAsync(workType, location, categoryId);
                return Ok(jobs);
            }

        }
    }

