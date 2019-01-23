using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace TheStore.Site.Authentication
{
    public class SiteUser : ClaimsPrincipal
    {
        public SiteUser(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public string Id => this.FindFirst(CustomClaims.Id)?.Value;

        public string Email => this.FindFirst(CustomClaims.Email)?.Value;

        public string Name => this.FindFirst(CustomClaims.Name)?.Value;
    }
}