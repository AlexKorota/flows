using System;
using System.Security.Claims;
using System.Threading.Tasks;
using flows.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace flows.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        // GET: api/Budget
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            var res = await _budgetService.GetAllUserBudgets(int.Parse(userId));

            return new OkObjectResult(res);
        }

        // GET: api/Budget/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudget(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            var res = await _budgetService.GetUserBudget(id, int.Parse(userId));
            return new OkObjectResult(res);
        }

        // POST: api/Budget
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Budget/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
