using AutoMapper;
using flows.Domain.DTO.Budget;
using flows.Domain.Entities;
using flows.Domain.Repositories.Interfaces;
using flows.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public async Task<List<BudgetDTO>> GetAllUserBudgets(int userId)
        {
            var budgets = await _budgetRepository.GetAsync(x => x.OwnerId.Equals(userId));
            return budgets.Select(b => _mapper.Map<BudgetDTO>(b)).ToList();
        }

        public async Task<BudgetDTO> GetUserBudget(int budgetId, int userId)
        {
            var res = await _budgetRepository.GetWithIncludeAsync(new CancellationToken(), x => x.Id == budgetId && x.OwnerId == userId, x => x.Expenses);
            if (res.Count() == 0)
                throw new ArgumentOutOfRangeException("can't find budget or you haven't enough permissions");
            return _mapper.Map<BudgetDTO>(res.FirstOrDefault());
        }
        public async Task CreateUserBudget(BudgetDTO dto, int userId)
        {
            Budget budget = _mapper.Map<Budget>(dto);
            await _budgetRepository.CreateAsync(budget);
        }

        public async Task DeleteUserBudget(int budgetId, int userId)
        {
            await _budgetRepository.RemoveAsync(x => x.Id == budgetId && x.OwnerId == userId);
        }

        public Task<BudgetDTO> EditUserBudget(EditBudgetDTO dto, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
