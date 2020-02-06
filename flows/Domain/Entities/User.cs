using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Helpers;


namespace flows.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        private string _password;
        [JsonIgnore]
        public string Password 
        {
            get { return _password; }
            set 
            {
                if (_password == null) 
                    _password = Crypto.HashPassword(value);
            }
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TelegramId { get; set; }
        public bool IsAdmin { get; }

        public virtual List<Budget> Budgets { get; set; }
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<ExpensesGroup> ExpensesGroups { get; set; }
    }
}
