﻿using AngularJSAuthentication.API.Old.Models;
using AngularJSAuthentication.API.Old.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularJSAuthentication.API.Old.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        public AuthRepository _repository;
        public AccountController()
        {
            _repository = new AuthRepository();
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IdentityResult result = await _repository.RegisterUser(userModel);
            IHttpActionResult errorResult = GetErrorResult(result);
            if(errorResult!=null)
            {
                return errorResult;
            }
            return Ok("User created successfully");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }

            base.Dispose(disposing);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if(result==null)
            {
                return InternalServerError();
            }
            if(!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
