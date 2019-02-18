namespace TheStore.Site.Areas.Admin.Models
{
    using System.Web;

    public class PictureSelector
    {
        public HttpPostedFileBase ImageFile { get; set; }

        public int? PictureId { get; set; }
    }
}