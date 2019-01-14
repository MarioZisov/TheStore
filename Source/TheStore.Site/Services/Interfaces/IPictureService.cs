namespace TheStore.Site.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TheStore.Site.Domain;

    public interface IPictureService
    {
        Picture InsertPicture(Picture picture);
    }
}