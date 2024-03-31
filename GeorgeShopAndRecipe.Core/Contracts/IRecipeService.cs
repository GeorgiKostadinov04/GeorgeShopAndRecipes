using GeorgeShopAndRecipe.Core.Models.Home;
using GeorgeShopAndRecipe.Core.Models.Recipe;

namespace GeorgeShopAndRecipe.Core.Contracts.Recipe
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeIndexServiceModel>> LastThreeRecipesAsync();

        Task<IEnumerable<RecipeCategoryServiceModel>> AllCategoriesAsync();

        Task<IEnumerable<RecipeIngredientServiceModel>> AllIngredientsAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<bool> IngredientExistsAsync(string ingredientName);

        Task<int> CreateAsync(RecipeFormModel model, int recipeDeveloperID);   

        Task<RecipeQueryServiceModel> AllAsync(string? category = null, 
            string? searchTerm = null, 
            int currentPage = 1,
            int recipesPerPage =1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();
    }
}
