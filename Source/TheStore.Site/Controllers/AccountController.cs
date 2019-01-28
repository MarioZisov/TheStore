namespace TheStore.Site.Controllers
{
    using Microsoft.Owin.Security;
    using System.Web;
    using System.Web.Mvc;
    using TheStore.Core.Domain;
    using TheStore.Site.Authentication;
    using TheStore.Site.Base;

    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            // TODO: Implement login logic here
            User user = new User();

            this.AuthenticationManager.SignIn(user);

            return this.RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            this.AuthenticationManager.SignOut();

            return this.RedirectToAction("Index");
        }

        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Home", new { ReturnUrl = returnUrl }));
        }

        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = this.HttpContext.GetOwinContext().Authentication.GetExternalLoginInfo();
            if (loginInfo == null)
            {
                return RedirectToAction("Index");
            }

            // TODO: Check if the user's email is registered in the User's table.
            // If it's not than create row in the User's table with the provided email
            // Create a row in externl user table with user's id provider key and name

            // If the external user exists than log in:
            User user = new User();
            this.AuthenticationManager.SignIn(user);

            return this.RedirectToAction("Index");
        }      
    }
}