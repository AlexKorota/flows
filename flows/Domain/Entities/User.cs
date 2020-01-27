using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
                    _password = BCrypt.Net.BCrypt.HashPassword(value, BCrypt.Net.BCrypt.GenerateSalt()); //TODO: вытащить соль из конфига
            } 
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TelegramId { get; set; }
        public bool IsAdmin { get; }
    }
}
