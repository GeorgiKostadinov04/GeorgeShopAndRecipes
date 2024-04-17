using GeorgeShopAndRecipe.Attributes;
using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Extensions;
using GeorgeShopAndRecipe.Core.Models.Recipe;
using GeorgeShopAndRecipe.Core.Services;
using GeorgeShopAndRecipe.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static GeorgeShopAndRecipe.Core.Constants.MessageConstants;

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

            if (User.IsAdmin())
            {
                return RedirectToAction("Mine", "Recipe", new { area = "Admin" });
            }

            int recipeDeveloperId = await recipeDeveloperService.GetRecipeDeveloperIdAsync(userId) ?? 0;
            model = await recipeService.AllRecipesByRecipeDeveloperIdAsync(recipeDeveloperId);
            

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if(await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await recipeService.RecipeDetailsByIdAsync(id);

            if(information != model.GetInformation())
            {
                return BadRequest();
            }

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
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            foreach(var i in model.Ingredients)
            {
                if(await recipeService.IngredientExistsAsync(i.Name) == false)
                {
                    ModelState.AddModelError(nameof(model.Ingredients), "Ingredient does not exist");
                };
            }

            if(ModelState.IsValid == false)
            {
                model.Categories = await recipeService.AllCategoriesAsync();

                model.Ingredients = await recipeService.AllIngredientsAsync();

                TempData[UserMessageSuccess] = "You have added a recipe!";

                return View(model);
            }

            int? recipeDeveloperId = await recipeDeveloperService.GetRecipeDeveloperIdAsync(User.Id());

            int newRecipeId = await recipeService.CreateAsync(model, recipeDeveloperId ?? 0);

            return RedirectToAction(nameof(Details), new {id = newRecipeId, information = model.GetInformation()});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if(await recipeService.HasRecipeDeveloperWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }


            var model = await recipeService.GetRecipeFormModelByIdAsync(id);
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, RecipeFormModel model)
        {
            if (await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await recipeService.HasRecipeDeveloperWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if(await recipeService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if(ModelState.IsValid == false)
            {
                model.Categories = await recipeService.AllCategoriesAsync();
                model.Ingredients = await recipeService.AllIngredientsAsync();

                return View(model);
            }

            await recipeService.EditAsync(id, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            

            if(await recipeService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if(await recipeService.HasRecipeDeveloperWithIdAsync(id, User.Id()) == false 
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var recipe = await recipeService.RecipeDetailsByIdAsync(id);

            var model = new RecipeDetailsViewModel()
            {
                Id = id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl,
            };

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(RecipeDetailsViewModel model)
        {
            if (await recipeService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await recipeService.HasRecipeDeveloperWithIdAsync(model.Id, User.Id()) == false 
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await recipeService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
