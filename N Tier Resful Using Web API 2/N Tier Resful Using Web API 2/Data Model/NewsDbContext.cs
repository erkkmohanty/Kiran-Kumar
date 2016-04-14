using N_Tier_Resful_Using_Web_API_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace N_Tier_Resful_Using_Web_API_2.Data_Model
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext() 
        {
            Database.SetInitializer(new NewsDbInitializer());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}