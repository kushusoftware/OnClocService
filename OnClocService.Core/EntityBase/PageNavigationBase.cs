#nullable disable

using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.EntityBase
{
    public class PageNavigationBase
    {
        [Display(Name = "Index"), Required]
        public int Index { get; set; }

        [Display(Name = "Name"), Required]
        public string Name { get; set; }

        [Display(Name = "Title"), Required]
        public string Title { get; set; }

        [Display(Name = "Description"), Required]
        public string Description { get; set; }

        [Display(Name = "Icon Class"), Required]
        public string IconClass { get; set; } = "mdi mdi-circle-double";

        [Display(Name = "Show"), Required]
        public bool ShowInMenu { get; set; } = true;

        [Display(Name = "Enable"), Required]
        public bool EnableMenuItem { get; set; } = true;
    }
}
