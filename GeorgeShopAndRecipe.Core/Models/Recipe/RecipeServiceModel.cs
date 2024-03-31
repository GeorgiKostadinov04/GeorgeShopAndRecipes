using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;
using static GeorgeShopAndRecipe.Core.Constants.MessageConstants;


namespace GeorgeShopAndRecipe.Core.Models.Recipe
{
    public class RecipeServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RecipeWayOfMakingMaxLength, MinimumLength = RecipeWayOfMakingMinLength,
           ErrorMessage = LengthMessage)]
        [Display(Name = "Way of making")]
        public string WayOfMaking { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}