using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Blogg_v2.Models
{
    public class PostViewModel
    {
       public PagedList.IPagedList<Post> Posts { get; set; }
       public IEnumerable<Category> Categories { get; set; }
    }
}