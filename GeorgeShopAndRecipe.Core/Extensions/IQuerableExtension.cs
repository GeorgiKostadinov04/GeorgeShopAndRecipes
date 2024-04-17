using GeorgeShopAndRecipe.Core.Models.Recipe;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableRecipeExtension
    {
        public static IQueryable<RecipeServiceModel> ProjectToRecipeServiceModel(this IQueryable<Recipe> recipes)
        {
            return recipes.Select(r => new RecipeServiceModel()
            {
                Id = r.Id,
                Name = r.Name,
                WayOfMaking = r.WayOfMaking,
                ImageUrl = r.ImageUrl,
            });
        }
    }
}
