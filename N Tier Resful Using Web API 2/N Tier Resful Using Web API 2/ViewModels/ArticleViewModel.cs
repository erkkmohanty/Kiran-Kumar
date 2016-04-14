using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N_Tier_Resful_Using_Web_API_2.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}