using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jobhunt.Context;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Jobhunt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.JobCategories.ToListAsync();
            return Ok(categories);
        }

    }
}
