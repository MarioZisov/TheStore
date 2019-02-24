namespace TheStore.Site.Areas.Admin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using TheStore.Core.Resources;
    using TheStore.Site.Resources.PagesTexts;

    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Subcategories = new MultiSelectDropDownList()
            {
                LabelText = "Подкатегории",
                ListItems = new List<MultiSelectDropDownListItem>(),
            };

            this.PictureSelector = new PictureSelector();
        }

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Name { get; set; }

        public int Order { get; set; }

        public bool IsPrimary { get; set; }

        public bool Visible { get; set; }

        public MultiSelectDropDownList Subcategories { get; set; }

        public PictureSelector PictureSelector { get; set; }
    }
}