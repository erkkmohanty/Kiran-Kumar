using N_Tier_Resful_Using_Web_API_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace N_Tier_Resful_Using_Web_API_2.Data_Model
{
    public class NewsDbInitializer : CreateDatabaseIfNotExists<NewsDbContext>
    {
        protected override void Seed(NewsDbContext context)
        {
            List<Author> authorsList = new List<Author>();
            for (var c = 0; c < 100; c++)
            {
                Author author = new Author
                {
                    Name = "Article " + c,
                    Articles = new List<Article>()
                };
                int numberOfArticles = new Random().Next(3, 10);
                for (var j = 0; j < numberOfArticles; j++)
                {
                    author.Articles.Add(
                        new Article
                        {
                            Title = "New Article Title",
                            Body = "New Article Body",
                            DatePosted = DateTime.Now
                        }
                        );
                }
                authorsList.Add(author);
            }
            context.Authors.AddRange(authorsList);
            base.Seed(context);
        }
    }
}