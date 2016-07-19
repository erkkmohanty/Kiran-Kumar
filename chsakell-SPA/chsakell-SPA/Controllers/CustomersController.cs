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
using chsakell_SPA.Infrastructure.Extensions;

namespace chsakell_SPA.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Customer> _customersRepository;

        public CustomersController(IEntityBaseRepository<Customer> customersRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
        }
        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Customer> customers = null;
                int totalMovies = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.Trim().ToLower();

                    customers = _customersRepository.GetAll()
                        .OrderBy(c => c.Id)
                        .Where(c => c.LastName.ToLower().Contains(filter) ||
                            c.IdentityCard.ToLower().Contains(filter) ||
                            c.FirstName.ToLower().Contains(filter))
                        .ToList();
                }
                else
                {
                    customers = _customersRepository.GetAll().ToList();
                }

                totalMovies = customers.Count();
                customers = customers.Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                IEnumerable<CustomerViewModel> customersVM = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

                PaginationSet<CustomerViewModel> pagedSet = new PaginationSet<CustomerViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalMovies,
                    TotalPages = (int)Math.Ceiling((decimal)totalMovies / currentPageSize),
                    Items = customersVM
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, CustomerViewModel customer)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    Customer _customer = _customersRepository.GetSingle(customer.ID);
                    _customer.UpdateCustomer(customer);

                    UnitOfWork.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }


        public HttpResponseMessage Register(HttpRequestMessage request, CustomerViewModel customer)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    //if (_customersRepository.UserExists(customer.Email, customer.IdentityCard))
                    //{
                    //    ModelState.AddModelError("Invalid user", "Email or Identity Card number already exists");
                    //    response = request.CreateResponse(HttpStatusCode.BadRequest,
                    //    ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                    //          .Select(m => m.ErrorMessage).ToArray());
                    //}
                    //else
                    //{
                    //    Customer newCustomer = new Customer();
                    //    newCustomer.UpdateCustomer(customer);
                    //    _customersRepository.Add(newCustomer);

                    //    UnitOfWork.Commit();

                    //    // Update view model
                    //    customer = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
                    //    response = request.CreateResponse<CustomerViewModel>(HttpStatusCode.Created, customer);
                    //}
                }

                return response;
            });
        }
    }
}
