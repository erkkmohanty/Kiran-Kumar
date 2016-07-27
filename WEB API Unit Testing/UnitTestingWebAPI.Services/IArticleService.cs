using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles(string name = null);
        Article GetArticle(int id);
        Article GetArticle(string name);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
        void SaveArticle();
    }
}
