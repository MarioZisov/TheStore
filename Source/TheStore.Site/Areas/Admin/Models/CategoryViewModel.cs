namespace TheStore.Site.Areas.Admin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;
    using TheStore.Core.Resources;
    using TheStore.Site.Resources.PagesTexts;

    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Subcategories = new MultiSelectDropDownList()
            {
                LabelText = GlobalTexts.Subcategories,
                ListItems = new List<MultiSelectDropDownListItem>()
            };
        }

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Name { get; set; }

        public int Order { get; set; }       

        public MultiSelectDropDownList Subcategories { get; set; }

        public bool IsPrimary { get; set; }

        public bool Visible { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}