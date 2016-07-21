using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using chsakell_SPA.Infrastructure.core;
using chsakell_SPA.Models;
using HomeCinema.DataRepositories.Infrastructure;
using HomeCinema.DataRepositories.Repositories;
using HomeCinema.Entities.Entities;

namespace chsakell_SPA.Controllers
{
    public class GenresController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Genre> _genresRepository;

        public GenresController(IEntityBaseRepository<Genre> genresRepository,
             IEntityBaseRepository<Error> errorsRepository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(errorsRepository, unitOfWork,mapper)
        {
            _genresRepository = genresRepository;
        }
        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var genres = _genresRepository.GetAll().ToList();

                IEnumerable<GenreViewModel> genresVm = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres);

                response = request.CreateResponse(HttpStatusCode.OK, genresVm);

                return response;
            });
        }
    }
}
