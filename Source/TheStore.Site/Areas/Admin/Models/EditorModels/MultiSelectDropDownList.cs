namespace TheStore.Site.Areas.Admin.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class MultiSelectDropDownList
    {        
        public string LabelText { get; set; }

        public IEnumerable<MultiSelectDropDownListItem> ListItems { get; set; }
    }
}