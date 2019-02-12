namespace TheStore.Site.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Resources;

    public class PictureBrowseViewModel
    {
        /// <summary>
        /// Name of <see cref="HttpPostedFileBase"/> property
        /// </summary>
        public string PropertyName { get; set; }
        
        private string imageUrl;
        /// <summary>
        /// If left empty returns default "No Image" url.
        /// </summary>
        public string ImageUrl
        {
            get
            {
                if (imageUrl == null)
                    imageUrl = Constants.NoImageUrl;

                return imageUrl;
            }
            set
            {
                this.imageUrl = value;
            }
        } 
    }
}