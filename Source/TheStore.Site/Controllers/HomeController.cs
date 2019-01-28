using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using TheStore.Site.Base;

namespace TheStore.Site.Controllers
{
    public class HomeController : BaseController
    {
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