using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.PostModels
{
    public class PostEdit
    {

        public int NoteId { get; set; }

        public int PostId { get; set; }

        public string Content { get; set; }
    }
}