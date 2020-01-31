using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public List<Expense> Expenses { get; set; }
        public List<ExpensesGroup> ExpensesGroups { get; set; }
    }
}
