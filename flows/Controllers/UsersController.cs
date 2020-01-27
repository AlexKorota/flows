using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flows.Data;
using flows.Domain.Entities;
using flows.Domain.Services.Interfaces;
using flows.Domain.DTO;
using Microsoft.AspNetCore.Authorization;

namespace flows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            var res = await _userService.GetUsersAsync();
            return new OkObjectResult(res);
        }

        [Authorize]
        [HttpGet("me")]
        // GET: api/Users/me
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var id = User.FindFirst(x => x.Type == JwtClaimTypes.Subject).Value;
            var res = await _userService.GetCurrentUser(int.Parse(id));
            return new OkObjectResult(res);
        }
    }
}
