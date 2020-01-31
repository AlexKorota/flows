using System;
using System.Security.Claims;
using System.Threading.Tasks;
using flows.Domain.DTO.Budget;
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
        public async Task<IActionResult> GetBudget(int budgetId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            var res = await _budgetService.GetUserBudget(budgetId, int.Parse(userId));
            return new OkObjectResult(res);
        }

        // POST: api/Budget
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BudgetDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            var res = await _budgetService.CreateUserBudget(dto, int.Parse(userId));
            return new OkObjectResult(res);
        }

        // PUT: api/Budget/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditBudgetDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            var res = await _budgetService.EditUserBudget(dto, int.Parse(userId));
            return new OkObjectResult(res);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int budgetId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            await _budgetService.DeleteUserBudget(budgetId, int.Parse(userId));
            return new OkResult();
        }
    }
}
