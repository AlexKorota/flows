using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.DTO
{
    public class RegistrationDTO : UserDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
