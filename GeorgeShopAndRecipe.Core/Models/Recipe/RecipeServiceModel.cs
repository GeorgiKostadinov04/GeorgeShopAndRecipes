using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;
using static GeorgeShopAndRecipe.Core.Constants.MessageConstants;
using GeorgeShopAndRecipe.Core.Contracts;


namespace GeorgeShopAndRecipe.Core.Models.Recipe
{
    public class RecipeServiceModel : IRecipeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength,
            ErrorMessage = SymbolMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RecipeWayOfMakingMaxLength, MinimumLength = RecipeWayOfMakingMinLength,
           ErrorMessage = SymbolMessage)]
        [Display(Name = "Way of making")]
        public string WayOfMaking { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}