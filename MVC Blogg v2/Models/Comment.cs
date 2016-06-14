using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Blogg_v2.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public DateTime DatePosted { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }


        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}