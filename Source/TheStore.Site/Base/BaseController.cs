namespace TheStore.Site.Base
{
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;
    using TheStore.Site.Authentication;

    public abstract class BaseController : Controller
    {
        public SiteUser CurrentUser => new SiteUser(this.User as ClaimsPrincipal);

        public AuthenticationManager AuthenticationManager => new AuthenticationManager(this.HttpContext.GetOwinContext());
    }
}