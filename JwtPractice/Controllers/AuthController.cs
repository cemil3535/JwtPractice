using JwtPractice.Dto;
using JwtPractice.Entities;
using JwtPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JwtPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        private readonly IConfiguration _configuration;

        public AuthController(UserDbContext context, IConfiguration configuration)
        {
            _userDbContext = context;
            _configuration = configuration;
        }

        // Kayit islemleri
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = registerDto.Email, Password = registerDto.Password };
                _userDbContext.Users.Add(user);
                await _userDbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(Register), new { id = user.Id }, user);


            }
            return BadRequest();
        }

        // Login islemleri
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var userQuery = _userDbContext.Users.Where(u => u.Email == loginDto.Email);
                var user = await userQuery.FirstOrDefaultAsync();

                if (user is null)
                {
                    return BadRequest();
                }

                //jwt
                var token = Helper.CreateJwtToken(user.Email, _configuration["Jwt:Key"], _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"]);
                return Ok(token);
            }
            return BadRequest();
        }

    }
}
