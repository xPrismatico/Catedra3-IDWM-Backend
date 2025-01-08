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

        [Required]
        public required string ImageUrl { get; set; } = null!;

        [Required]
        public required DateTime PublishDate { get; set; }
    }
}