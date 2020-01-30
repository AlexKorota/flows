using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Entities
{
    public class ExpensesGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BudgetId{ get; set; }
        public Budget Budget { get; set; }
        public int OwnerId{ get; set; }
        public User Owner { get; set; }
    }
}
