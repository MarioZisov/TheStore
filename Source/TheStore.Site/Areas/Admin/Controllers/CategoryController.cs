﻿namespace TheStore.Site.Areas.Admin.Controllers
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
    using TheStore.Site.Resources;
    using System.Net;

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
            if (categoryVM.PictureSelector.ImageFile == null)
                this.ModelState.AddModelError(nameof(categoryVM.PictureSelector), ValidationMessages.Required);

            if (this.ModelState.IsValid == false)
                return this.View(categoryVM);

            string categoriesImagesPath = WebConfigurationManager.AppSettings[Constants.CategoriesImagesPath_ConfigKey];
            string serverPath = this.Server.MapPath(categoriesImagesPath);

            var pictureRequest = new CreatePictureRequest
            {
                ContentType = categoryVM.PictureSelector.ImageFile.ContentType,
                FileExtention = Path.GetExtension(categoryVM.PictureSelector.ImageFile.FileName),
                InputStream = categoryVM.PictureSelector.ImageFile.InputStream,
                ServerPath = serverPath,
                UrlPath = categoriesImagesPath,
            };

            var pictureResponse = this.pictureService.Create(pictureRequest);

            if (pictureResponse.Result != CreatePictureResult.Success)
            {
                this.ModelState.AddModelError(nameof(categoryVM.PictureSelector.ImageFile), pictureResponse.Message);
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

            return this.View(vm);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryVM)
        {
            if (categoryVM.PictureSelector.ImageFile == null && categoryVM.PictureSelector.PictureId == null)
                this.ModelState.AddModelError(nameof(categoryVM.PictureSelector), ValidationMessages.Required);

            if (this.ModelState.IsValid == false)            
                return this.View(categoryVM);            

            CreatePictureResponse pictureResponse = null;
            if (categoryVM.PictureSelector.ImageFile != null)
            {
                string categoriesImagesPath = WebConfigurationManager.AppSettings[Constants.CategoriesImagesPath_ConfigKey];
                string serverPath = this.Server.MapPath(categoriesImagesPath);

                var pictureRequest = new CreatePictureRequest
                {
                    ContentType = categoryVM.PictureSelector.ImageFile.ContentType,
                    FileExtention = Path.GetExtension(categoryVM.PictureSelector.ImageFile.FileName),
                    InputStream = categoryVM.PictureSelector.ImageFile.InputStream,
                    ServerPath = serverPath,
                    UrlPath = categoriesImagesPath,
                };

                pictureResponse = this.pictureService.Create(pictureRequest);

                if (pictureResponse.Result != CreatePictureResult.Success)
                {
                    this.ModelState.AddModelError(nameof(categoryVM.PictureSelector.ImageFile), pictureResponse.Message);
                    return this.View(categoryVM);
                }
            }

            var updateRequest = new UpdateCategoryRequest()
            {
                Id = categoryVM.Id,
                Name = categoryVM.Name,
                DisplayOrder = categoryVM.Order,
                IsPrimary = categoryVM.IsPrimary,
                Visible = categoryVM.Visible,
                PictureId = pictureResponse?.Picture.Id,
            };

            updateRequest.SelectedCategoriesIds = categoryVM.Subcategories.ListItems
                                                                    .Where(x => x.Checked)
                                                                    .Select(x => int.Parse(x.Id));

            this.categoryService.Update(updateRequest);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = this.categoryService.Delete(id);
            if (category == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return this.RedirectToAction("Index");
        }
    }
}