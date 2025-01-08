using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra3_IDWM_Backend.src.DTOs
{
    public class PostDto
    {
        [Required, StringLength(255, MinimumLength = 5)]
        public required string Title { get; set; } = null!;

        public required string ImageUrl { get; set; } = null!;


        [Required, EmailAddress]
        public required string Email { get; set; }
    }
}