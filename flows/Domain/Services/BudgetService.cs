using AutoMapper;
using flows.Domain.DTO.Budget;
using flows.Domain.Entities;
using flows.Domain.Repositories.Interfaces;
using flows.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IGenericRepository<Budget> _budgetRepository;
        private readonly IMapper _mapper;
        public BudgetService(IGenericRepository<Budget> budgetRepository, IMapper mapper)
        {
            _budgetRepository = budgetRepository;
            _mapper = mapper;
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
