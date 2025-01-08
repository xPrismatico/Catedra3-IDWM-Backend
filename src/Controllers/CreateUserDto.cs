using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.src.ValidationAttribute;

namespace Catedra3_IDWM_Backend.src.Controllers
{
    public class CreateUserDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, StringLength(20, MinimumLength = 6), PasswordContainsNumber] //revisar
        public string Password { get; set; } = null!;
    }
}