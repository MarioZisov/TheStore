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
    using TheStore.Site.ModelsFactories.Interfaces;

    public class CategoryController : BaseController
    {
        private readonly IPictureService pictureService;
        private readonly ICategoryService categoryService;
        private readonly ICategoryModelFactory categoryModelFactory;

        public CategoryController(IPictureService pictureService, ICategoryService categoryService, ICategoryModelFactory categoryModelFactory)
        {
            this.pictureService = pictureService ?? throw new ArgumentNullException(nameof(pictureService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.categoryModelFactory = categoryModelFactory ?? throw new ArgumentNullException(nameof(categoryModelFactory));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var vm = this.categoryModelFactory.ProduceCategroyCreateModel();
            return this.View(vm);
        }        

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryVM)
        {
            if (this.ModelState.IsValid == false)
                return this.View(categoryVM);

            string categoriesImagesPath = WebConfigurationManager.AppSettings[Constants.CategoriesImagesPath_ConfigKey];
            string savePath = this.Server.MapPath(categoriesImagesPath);

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
            var selectedCategoriesIds = categoryVM.Subcategories.ListItems.Where(x => x.Checked).Select(x => int.Parse(x.Id));

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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = this.categoryService.GetById(id);
            if (category == null)
                return new HttpNotFoundResult();

            var vm = this.categoryModelFactory.ProduceCategoryEditModel(category);

            return this.View("Edit", vm);
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
    }
}