namespace TheStore.Site.Areas.Admin.Controllers
{
    using System;
    using System.IO;
    using System.Web.Configuration;
    using System.Web.Mvc;
    using TheStore.Site.Areas.Admin.Models;
    using TheStore.Site.Common;
    using TheStore.Site.Domain;
    using TheStore.Site.Services.Interfaces;

    public class CategoryController : Controller
    {
        private readonly IPictureService pictureService;

        public CategoryController(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }

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

        public ActionResult GetImage(string imageName)
        {
            if (Request.QueryString["imageName"] != null)
            {
                string imagePath = Server.MapPath($@"~/storage/images/categories/{imageName}.jpg");

                return File(imagePath, "image/jpg");    
            }

            return null;
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryVM)
        {
            //if (this.ModelState.IsValid == false)
            //    return View(categoryVM);

            string contentType = categoryVM.ImageFile.ContentType;
            string fileExtention = Path.GetExtension(categoryVM.ImageFile.FileName);

            bool isPicture = FileHelper.IsPicture(categoryVM.ImageFile.ContentType, fileExtention);
            //if (isPicture == false)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Навалиден формат на файла");
            //    return this.View(categoryVM);
            //}

            bool isValidFileSize = FileHelper.IsValidImageSize(categoryVM.ImageFile.ContentLength);
            //if (isValidFileSize == false)
            //{
            //    this.ModelState.AddModelError(string.Empty, "Прекалено голяма снимка");
            //    return this.View(categoryVM);
            //}
            
            string picName = FileHelper.GeneratePictureName(fileExtention);

            string categoriesImagesPath = WebConfigurationManager.AppSettings["categoriesPath"];
            string savePath = Server.MapPath($@"{categoriesImagesPath}{picName}");
            categoryVM.ImageFile.SaveAs(savePath);

            Picture picture = new Picture { Url = savePath };

            picture = this.pictureService.InsertPicture(picture);


            return View(categoryVM);
        }
    }
}