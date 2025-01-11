using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.src.ValidationAttribute;
using Microsoft.AspNetCore.Identity;

namespace api.src.Models
{
    public class User : IdentityUser
    {
        //[Key]
        //public int UserId { get; set; }
        
        [Required, EmailAddress]
        public new string Email { get; set; } = null!;

        [Required, StringLength(20, MinimumLength = 6), PasswordContainsNumber] //revisar
        public string Password { get; set; } = null!;


        public List<Post> Posts { get; set; } = null!;

    }
}