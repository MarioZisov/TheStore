namespace TheStore.Site.Authentication
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;
    using TheStore.Core.Domain;

    public class AuthenticationManager
    {
        private readonly IAuthenticationManager authenticationManager;

        public AuthenticationManager(IOwinContext owinContext)
        {
            this.authenticationManager = owinContext.Authentication;
        }

        public void SignIn(User user)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(CustomClaims.Id, user.Id.ToString()),
                new Claim(CustomClaims.Email, user.Email),
                new Claim(CustomClaims.Name, user.FirstName),
            }
            , DefaultAuthenticationTypes.ApplicationCookie);

            this.authenticationManager.SignIn(identity);
        }

        public void SignOut()
        {
            this.authenticationManager.SignOut();
        }
    }
}