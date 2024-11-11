using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api_backend.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUsernameOrEmail(this ClaimsPrincipal user)
        {
            var result = user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
            if (string.IsNullOrEmpty(result))
            {
                result = user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")).Value;
            }
            return result;
        }
    }
}