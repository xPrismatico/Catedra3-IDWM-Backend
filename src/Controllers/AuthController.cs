using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using api.src.Models;
using System.Threading.Tasks;
using Catedra3_IDWM_Backend.src.DTOs;
using Catedra3_IDWM_Backend.src.Controllers;
using Catedra3_IDWM_Backend.src.Interfaces;
namespace api.src.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IJwtService jwtService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = new User
            {
                UserName = userDto.Email,
                Email = userDto.Email,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Invalid login data.");
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized("Invalid credentials: User does not exist.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid credentials: Incorrect password.");
            }

            var token = _jwtService.GenerateJwtToken(loginDto.Email);
            return Ok(new { token, email = user.Email });
        }
    }
}