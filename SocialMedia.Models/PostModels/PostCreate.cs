using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.PostModels
{
    public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter more than 2 characters")]
        [MaxLength(8000, ErrorMessage = "Post is WAYYYYY too long")]
        public string Content { get; set; }

        [Required]
        public int CommentId { get; set; }
    }
}