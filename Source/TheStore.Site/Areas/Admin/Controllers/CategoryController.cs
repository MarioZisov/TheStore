namespace TheStore.Site.Areas.Admin.Controllers
{
    using System;
    using System.IO;
    using System.Web.Configuration;
    using System.Web.Mvc;
    using TheStore.Site.Areas.Admin.Models;
    using TheStore.Services.Interfaces;
    using TheStore.Site.Base;
    using TheStore.Core.Resources;
    using System.Linq;
    using TheStore.Services.PictureServiceComponents;
    using TheStore.Services.CategoryServiceComponents;
    using System.Collections.Generic;

    public class CategoryController : BaseController
    {
        private readonly IPictureService pictureService;
        private readonly ICategoryService categoryService;

        public CategoryController(IPictureService pictureService, ICategoryService categoryService)
        {
            this.pictureService = pictureService ?? throw new ArgumentNullException(nameof(pictureService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            return this.View("List");
        }

        public ActionResult Create()
        {
            var dropDownItems = this.categoryService.GetAll().Select(x => new MultiSelectDropDownListItem
            {
                Id = x.Id.ToString(),
                Text = x.Name,
                Checked = false,
            });

            CategoryViewModel categoryVM = new CategoryViewModel();
            categoryVM.Subcategories.ListItems = dropDownItems;

            return this.View(categoryVM);
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
            if (this.ModelState.IsValid == false)
                return this.View(categoryVM);

            string categoriesImagesPath = WebConfigurationManager.AppSettings[Constants.CategoriesImagesPath_ConfigKey];
            string savePath = Server.MapPath(categoriesImagesPath);

            var pictureRequest = new CreatePictureRequest
            {
                ContentType = categoryVM.ImageFile.ContentType,
                FileExtention = Path.GetExtension(categoryVM.ImageFile.FileName),
                InputStream = categoryVM.ImageFile.InputStream,
                SavePath = savePath,
            };

            var pictureResponse = this.pictureService.Create(pictureRequest);

            if (pictureResponse.Result != CreatePictureResult.Success)
            {
                this.ModelState.AddModelError(nameof(categoryVM.ImageFile), pictureResponse.Message);
                return this.View(categoryVM);
            }

            int pictureId = pictureResponse.Picture.Id;
            var selectedCategoriesIds = categoryVM.Subcategories.ListItems.Select(x => int.Parse(x.Id));

            var categoryRequest = new CreateCategoryRequest
            {
                Name = categoryVM.Name,
                DisplayOrder = categoryVM.Order,
                IsPrimary = categoryVM.IsPrimary,
                Visible = categoryVM.Visible,
                PictureId = pictureId,
                SelectedCategoriesIds = selectedCategoriesIds,
            };

            this.categoryService.Create(categoryRequest);

            return this.RedirectToAction("Index");
        }
    }
}