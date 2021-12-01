using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.ReplyModels
{
    public class ReplyCreate
    {
        public int ReplyId { get; set; }

        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        [Required]
        public string ReplyName { get; set; }

        public override string ToString() => ReplyName;
    }
}