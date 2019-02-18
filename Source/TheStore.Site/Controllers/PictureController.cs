using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheStore.Services.Interfaces;
using TheStore.Site.Base;

namespace TheStore.Site.Controllers
{
    [RoutePrefix("picture")]
    public class PictureController : BaseController
    {
        private readonly IPictureService pictureService;

        public PictureController(IPictureService pictureService)
        {
            this.pictureService = pictureService ?? throw new ArgumentNullException(nameof(pictureService));
        }

        [Route("{id:int}", Name = "Image")]
        public ActionResult Index(int id)
        {
            var picture = this.pictureService.GetById(id);
            if (picture == null)
                return new HttpNotFoundResult();

            return this.File(picture.FullPath, "image/jpg");
        }
    }
}