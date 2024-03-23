using GeorgeShopAndRecipe.Core.Models.Home;

namespace GeorgeShopAndRecipe.Core.Contracts.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeIndexServiceModel>> LastThreeRecipesAsync();
    }
}
