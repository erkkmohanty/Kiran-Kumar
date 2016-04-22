using Accounts_Management_With_ASP.NET_Identity.Infrastructure;
using Accounts_Management_With_ASP.NET_Identity.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Accounts_Management_With_ASP.NET_Identity.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private ApplicationUserManager _applicationUsermanager;
        public ModelFactory(HttpRequestMessage requestMessage,ApplicationUserManager appUserManager)
        {
            _urlHelper = new UrlHelper(requestMessage);
            _applicationUsermanager = appUserManager;
        }

        public UserReturnModel Create(ApplicationUser appUser)
        {
            return new UserReturnModel
            {
                Url = _urlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                UserName = appUser.UserName,
                FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Level = appUser.Level,
                JoinDate = appUser.JoinDate,
                Roles = _applicationUsermanager.GetRolesAsync(appUser.Id).Result,
                Claims = _applicationUsermanager.GetClaimsAsync(appUser.Id).Result
            };
        }
    }
    public class UserReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Level { get; set; }
        public DateTime JoinDate { get; set; }
        public IList<string> Roles { get; set; }
        public IList<System.Security.Claims.Claim> Claims { get; set; }
    }
}