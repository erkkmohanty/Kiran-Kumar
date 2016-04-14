using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N_Tier_Resful_Using_Web_API_2.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}