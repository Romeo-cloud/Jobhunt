using Jobhunt.Context;
using Jobhunt.Models.Auth;
using Jobhunt.Services;
using Jobhunt.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Jobhunt.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) ||
               string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.Username) ||
                string.IsNullOrEmpty(request.Role))
            {
                return BadRequest("All fields are required and cannot be empty or contain only spaces.");
            }


            if (_context.Users.Any(u => u.Email == request.Email || u.Username == request.Username))
                return BadRequest("Email or Username already in use.");

            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Registered Successfully");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return Unauthorized("Invalid Credentials.");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });

        }
    }
}