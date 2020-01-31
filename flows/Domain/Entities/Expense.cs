using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Entities
{
    public class Expense
    {
        public Int64 Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Cost { get; set; }
        public int? ExpensesGroupId { get; set; }
        public ExpensesGroup ExpensesGroup { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}
