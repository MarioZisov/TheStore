namespace TheStore.Services.CategoryServiceComponents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UpdateCategoryRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPrimary { get; set; }

        public int? PictureId { get; set; }

        public bool Visible { get; set; }

        public IEnumerable<int> SelectedCategoriesIds { get; set; }    
    }
}
