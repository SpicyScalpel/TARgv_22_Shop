using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Cocktails
{
    public class SearchCocktailViewModel
    {
        [Required(ErrorMessage = "You must enter a coctail name!")]
        [Display(Name = "Cocktail Name")]
        public string SearchCocktail { get; set; }
    }
}
