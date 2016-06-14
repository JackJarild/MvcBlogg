using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Blogg_v2.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "A Title is required")]
        [StringLength(34)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set;}

        public DateTime DateCreated { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [StringLength(285)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "Image URL")]
        [StringLength(1024)]
        public string ImageUrl { get; set; }


        public virtual Category Category { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}