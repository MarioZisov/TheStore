using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheStore.Site.Authentication;
using TheStore.Site.Base;
using TheStore.Site.Models;

namespace TheStore.Site.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            var authMng = new AuthenticationManager(this.Request.GetOwinContext());
            Core.Domain.User user = new Core.Domain.User
            {
                Id = 13,
                Email = "pp@abv.bg",
                FirstName = "Petar",
            };

            authMng.SignIn(user);

            return this.RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}