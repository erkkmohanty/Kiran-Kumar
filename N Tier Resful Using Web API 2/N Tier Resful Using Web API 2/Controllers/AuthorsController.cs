using N_Tier_Resful_Using_Web_API_2.Data_Model;
using N_Tier_Resful_Using_Web_API_2.Models;
using N_Tier_Resful_Using_Web_API_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace N_Tier_Resful_Using_Web_API_2.Controllers
{
    public class AuthorsController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            using (NewsDbContext context = new NewsDbContext())
            {
                var authors = await context.Authors.Select(o => new AuthorViewModel()
                {
                    Id = o.Id,
                    Name = o.Name
                }).ToListAsync();
                return Ok(authors);
            }
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            using (NewsDbContext context = new NewsDbContext())
            {
                Author author = await context.Authors.FirstOrDefaultAsync(auth => auth.Id == id);
                if (author == null)
                    return NotFound();
                var authorData = new AuthorViewModel() { Id = author.Id, Name = author.Name };
                return Ok(authorData);

            }
        }

        public async Task<IHttpActionResult> Post(CreateAuthorViewModel authorViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            using (NewsDbContext context = new NewsDbContext())
            {
                Author author = new Author { Name = authorViewModel.Name };
                context.Authors.Add(author);
                await context.SaveChangesAsync();

                var data = new AuthorViewModel { Id = author.Id, Name = author.Name };
                return Created(new Uri(Request.RequestUri + "api/authors" + data.Id), data);
            }
        }

        public async Task<IHttpActionResult> Put(EditAuthorViewModel editViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            using (NewsDbContext context = new NewsDbContext())
            {
                Author author = new Author() { Id = editViewModel.Id.Value, Name = editViewModel.Name };
                context.Authors.Attach(author);
                context.Entry(author).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            using (NewsDbContext context = new NewsDbContext())
            {
                var author = await context.Authors.FirstOrDefaultAsync(auth => auth.Id == id);
                if (author == null)
                    return NotFound();
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
      
    }
}
