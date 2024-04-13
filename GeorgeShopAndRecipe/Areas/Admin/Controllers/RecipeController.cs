using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Models.Admin;
using GeorgeShopAndRecipe.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GeorgeShopAndRecipe.Areas.Admin.Controllers
{
    public class RecipeController : AdminBaseController
    {
        private readonly IRecipeService recipeService;
        private readonly IRecipeDeveloperService recipeDeveloperService;

        public RecipeController(IRecipeService _recipeService, IRecipeDeveloperService _recipeDeveloperService)
        {
            recipeService = _recipeService;
            recipeDeveloperService = _recipeDeveloperService;
        }
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var recipeDeveloperId = await recipeDeveloperService.GetRecipeDeveloperIdAsync(userId) ?? 0;

            var myRecipes = new MyRecipesViewModel()
            {
                AddedRecipes = await recipeService.AllRecipesByRecipeDeveloperIdAsync(recipeDeveloperId)
            };

            return View(myRecipes);
        }
        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            var model = await recipeService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int recipeId)
        {
            await recipeService.ApproveRecipeAsync(recipeId);

            return RedirectToAction(nameof(Approve));
        }
    }
}
