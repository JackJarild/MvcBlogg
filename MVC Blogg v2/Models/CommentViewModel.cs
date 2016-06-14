using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Blogg_v2.Models
{
    public class CommentViewModel
    {
        public Post Post { get; set; }

        public Comment Comment { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}