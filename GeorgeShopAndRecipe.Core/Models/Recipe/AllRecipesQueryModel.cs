using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GeorgeShopAndRecipe.Core.Models.Recipe
{
    public class AllRecipesQueryModel
    {
        public int RecipePerPage { get; } = 3;

        public string Category { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchItem { get; set; } = null!;

        public int CurrentPage { get; set; } = 1;

        public int TotalRecipesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<RecipeServiceModel> Recipes { get; set; } = new List<RecipeServiceModel>();
    }
}
