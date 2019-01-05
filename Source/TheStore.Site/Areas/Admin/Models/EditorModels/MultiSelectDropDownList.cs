namespace TheStore.Site.Areas.Admin.Models
{
    using System.Collections.Generic;

    public class MultiSelectDropDownList
    {
        public string LabelText { get; set; }

        public IEnumerable<MultiSelectDropDownListItem> ListItems { get; set; }
    }
}