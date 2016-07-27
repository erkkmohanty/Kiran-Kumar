using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingWebAPI.Data.Infrastructure;
using UnitTestingWebAPI.Data.Repositories;
using UnitTestingWebAPI.Domain;

namespace UnitTestingWebAPI.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository blogsRepository;
        private readonly IUnitOfWork unitOfWork;

        public BlogService(IBlogRepository blogsRepository, IUnitOfWork unitOfWork)
        {
            this.blogsRepository = blogsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IBlogService Members

        public IEnumerable<Blog> GetBlogs(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return blogsRepository.GetAll();
            else
                return blogsRepository.GetAll().Where(c => c.Name == name);
        }

        public Blog GetBlog(int id)
        {
            var blog = blogsRepository.GetById(id);
            return blog;
        }

        public Blog GetBlog(string name)
        {
            var blog = blogsRepository.GetBlogByName(name);
            return blog;
        }

        public void CreateBlog(Blog blog)
        {
            blogsRepository.Add(blog);
        }

        public void UpdateBlog(Blog blog)
        {
            blogsRepository.Update(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            blogsRepository.Delete(blog);
        }

        public void SaveBlog()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
