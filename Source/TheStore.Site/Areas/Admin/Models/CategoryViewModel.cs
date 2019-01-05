using System.Collections.Generic;
using System.Web.Mvc;

namespace TheStore.Site.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {           
            this.Subcategories = new MultiSelectDropDownList
            {
                LabelText = "Подкатегории",
                ListItems = new List<MultiSelectDropDownListItem>
                {
                        new MultiSelectDropDownListItem
                    {
                        Text = "Лаптопи",
                        Id = "1",
                        Checked = false,
                    },
                    new MultiSelectDropDownListItem
                    {
                        Text = "Таблети",
                        Id = "2",
                        Checked = false,
                    },
                    new MultiSelectDropDownListItem
                    {
                        Text = "Телефони",
                        Id = "3",
                        Checked = false,
                    }
                }
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }       

        public MultiSelectDropDownList Subcategories { get; set; }       

        public bool IsPrimary { get; set; }

        public bool Visible { get; set; }
    }
}