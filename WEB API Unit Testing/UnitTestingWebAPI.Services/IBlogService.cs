using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Services
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetBlogs(string name = null);
        Blog GetBlog(int id);
        Blog GetBlog(string name);
        void CreateBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void SaveBlog();
        void DeleteBlog(Blog blog);
    }
}
