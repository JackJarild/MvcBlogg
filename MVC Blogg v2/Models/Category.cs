using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Blogg_v2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }
    }
}