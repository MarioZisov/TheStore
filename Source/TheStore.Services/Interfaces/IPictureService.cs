namespace TheStore.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TheStore.Core.Domain;

    public interface IPictureService
    {
        Picture InsertPicture(Picture picture);
    }
}