using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Accounts_Management_With_ASP.NET_Identity.Infrastructure
{
    public static class ExtendedClaimsProvider
    {
        public static IEnumerable<Claim> GetClaims(this ApplicationUser user)
        {
            List<Claim> claimList = new List<Claim>();

            var daysInWork = DateTime.Now.Date.Subtract(user.JoinDate).TotalDays;
            if(daysInWork>90)
            {
                claimList.Add(CreateClaim("FTE","1"));
            }
            else
            {
                claimList.Add(CreateClaim("FTE", "0"));
            }
            return claimList;
        }

        public static Claim CreateClaim(string claimType,string claimValue)
        {
            return new Claim(claimType, claimValue, ClaimValueTypes.String);
        }
    }
}