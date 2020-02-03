using flows.Domain.DTO.Budget;
using flows.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        public BudgetService()
        {
                
        }
        public Task<List<BudgetDTO>> GetAllUserBudgets(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<BudgetDTO> GetUserBudget(int budgetId, int userId)
        {
            throw new NotImplementedException();
        }
        public Task<BudgetDTO> CreateUserBudget(BudgetDTO dto, int userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserBudget(int budgetId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<BudgetDTO> EditUserBudget(EditBudgetDTO dto, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
