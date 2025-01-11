using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.src.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required, StringLength(255, MinimumLength = 5)]
        public required string Title { get; set; } = null!;


        [Required]
        public required DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey("User")]
        public required string UserId { get; set; }
        public User User { get; set; } = null!;
    }
}