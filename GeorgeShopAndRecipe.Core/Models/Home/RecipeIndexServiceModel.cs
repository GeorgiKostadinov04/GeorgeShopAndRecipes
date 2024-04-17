using GeorgeShopAndRecipe.Core.Contracts;

namespace GeorgeShopAndRecipe.Core.Models.Home
{
    public class RecipeIndexServiceModel : IRecipeModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
