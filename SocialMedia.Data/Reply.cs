using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required, Display(Name = "ContentReply")]
        public string ContentReply { get; set; }
        public string ReplyName { get; set; }
    }
}