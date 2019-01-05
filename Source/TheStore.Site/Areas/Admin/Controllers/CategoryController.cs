namespace TheStore.Site.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using TheStore.Site.Areas.Admin.Models;

    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            CategoryViewModel categoryVM = new CategoryViewModel();
            return View(categoryVM);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryVM)
        {
            return View(categoryVM);
        }
    }
}