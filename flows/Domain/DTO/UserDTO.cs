using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(15, MinimumLength = 2)]
        public string Name { get; set; }
        public string TelegramId { get; set; }
    }
}
