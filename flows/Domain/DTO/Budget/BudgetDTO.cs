using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.DTO.Budget
{
    public class BudgetDTO
    {
        public int Id;
        public string Name;
        public List<Expense> Expenses { get; set; }
        public List<ExpensesGroup> ExpensesGroups { get; set; }
    }
}
