using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheStore.Site.Models;

namespace TheStore.Site.Controllers
{
    public class HomeController : Controller
    {
        private TheStoreContext context;

        public HomeController()
        {

        }

        public HomeController(TheStoreContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
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