using GeorgeShopAndRecipe.Attributes;
using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Models.Recipe;
using GeorgeShopAndRecipe.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeorgeShopAndRecipe.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;

        private readonly IRecipeDeveloperService recipeDeveloperService;

        public RecipeController(IRecipeService _recipeService, IRecipeDeveloperService _recipeDeveloperService)
        {
            recipeService = _recipeService;
            recipeDeveloperService = _recipeDeveloperService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllRecipesQueryModel query)
        {
            var model = await recipeService.AllAsync(
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                query.RecipePerPage);

            query.TotalRecipesCount = model.TotalRecipesCount;
            query.Recipes = model.Recipes;
            query.Categories = await recipeService.AllCategoriesNamesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<RecipeServiceModel> model;

            int recipeDeveloperId = await recipeDeveloperService.GetRecipeDeveloperIdAsync(userId) ?? 0;
            model = await recipeService.AllRecipesByRecipeDeveloperIdAsync(recipeDeveloperId);
            

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            if(await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await recipeService.RecipeDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [MustBeRecipeDeveloper]
        public async Task<IActionResult> Add()
        {
            
            var model = new RecipeFormModel()
            {
                Categories = await recipeService.AllCategoriesAsync(),
                Ingredients = await recipeService.AllIngredientsAsync(),

            };

            return View(model);
        }

        [HttpPost]
        [MustBeRecipeDeveloper]
        public async Task<IActionResult> Add(RecipeFormModel model)
        {
            if(await recipeService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }

            foreach(var i in model.Ingredients)
            {
                if(await recipeService.IngredientExistsAsync(i.Name) == false)
                {
                    ModelState.AddModelError(nameof(model.Ingredients), "");
                };
            }

            if(ModelState.IsValid == false)
            {
                model.Categories = await recipeService.AllCategoriesAsync();

                model.Ingredients = await recipeService.AllIngredientsAsync();

                return View(model);
            }

            int? recipeDeveloperId = await recipeDeveloperService.GetRecipeDeveloperIdAsync(User.Id());

            int newRecipeId = await recipeService.CreateAsync(model, recipeDeveloperId ?? 0);

            return RedirectToAction(nameof(Details), new {id = newRecipeId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new RecipeFormModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, RecipeFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new RecipeDetailsViewModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(RecipeDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }
    }
}
