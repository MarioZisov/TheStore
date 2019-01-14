namespace TheStore.Site.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using TheStore.Site.Data;
    using TheStore.Site.Domain;
    using TheStore.Site.Services.Interfaces;

    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> pictureRepository;

        public PictureService(IRepository<Picture> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }

        public Picture InsertPicture(Picture picture)
        {
            if (picture == null)
                return null;

            this.pictureRepository.Insert(picture);

            return picture;
        }
    }    
}