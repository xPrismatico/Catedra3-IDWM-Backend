using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra3_IDWM_Backend.src.DTOs
{
    public class AuthDto
    {
        [Required, Key]
        public required int UserId { get; set; }
        
        [Required, EmailAddress]
        public required string Email { get; set; } = null!;
        [Required]
        public required string Token { get; set; } = null!;
    }
}