using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Coctails
{
    public class SearchCoctailViewModel
    {
        [Required(ErrorMessage = "You must enter a coctail name!")]
        [Display(Name = "Coctail Name")]
        public string CoctailName { get; set; }
    }
}
