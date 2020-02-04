using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using flows.Domain.Services.Interfaces;
using flows.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using flows.Helpers;
using System.Security.Claims;
using System;

namespace flows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var res = await _userService.GetUsersAsync();
            return new OkObjectResult(res);
        }

        [Authorize]
        [HttpGet("me")]
        // GET: api/Users/me
        public async Task<IActionResult> GetMe()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            if (email == null)
                return BadRequest();
            try
            {
                UserDTO dto = await _userService.GetUserAsync(email);
                return new OkObjectResult(dto);
            } 
            catch (ArgumentNullException e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userService.RegisterUserAsync(dto);
            return new OkResult();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CredentialsDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var identity = await _userService.GetUserIdentityAsync(dto);
            if (identity == null)
                return Unauthorized();

            var jwt = JwtCreator.Create(identity);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new OkObjectResult(new { access_token = encodedJwt });
        }
    }
}
