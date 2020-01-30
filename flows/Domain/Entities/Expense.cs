using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Entities
{
    public class Expense
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int ExpensesGroupId { get; set; }
        public ExpensesGroup ExpensesGroup { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}
