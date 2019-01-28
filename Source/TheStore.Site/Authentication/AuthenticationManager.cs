namespace TheStore.Site.Authentication
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using TheStore.Core.Domain;

    public class AuthenticationManager
    {
        public static readonly string XsrfKey = "XsrfId";
        private readonly IAuthenticationManager authenticationManager;

        public AuthenticationManager(IOwinContext owinContext)
        {
            this.authenticationManager = owinContext.Authentication;
        }

        public void SignIn(User user)
        {
            this.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            }
            , DefaultAuthenticationTypes.ApplicationCookie);

            this.authenticationManager.SignIn(identity);
        }

        public void SignOut()
        {
            this.authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.ApplicationCookie);
        }

        public void SignOut(params string[] authenticationTypes)
        {
            this.authenticationManager.SignOut(authenticationTypes);
        }

        public async Task<ClaimsIdentity> GetExternalIdeityAsync()
        {            
            var result = await this.authenticationManager.AuthenticateAsync(DefaultAuthenticationTypes.ExternalCookie);
            if (result != null && result.Identity != null &&
            result.Identity.FindFirst(ClaimTypes.NameIdentifier) != null)
            {
                return result.Identity;
            }
            return null;
        }
    }
}