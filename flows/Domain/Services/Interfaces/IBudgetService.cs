using flows.Domain.DTO.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Services.Interfaces
{
    public interface IBudgetService
    {
        public Task<List<BudgetDTO>> GetAllUserBudgets(int userId);
        public Task<BudgetDTO> GetUserBudget(int budgetId, int userId);
        public Task CreateUserBudget(BudgetDTO dto, int userId);
        public Task<BudgetDTO> EditUserBudget(EditBudgetDTO dto, int userId);
        public Task DeleteUserBudget(int budgetId, int userId);
    }
}
