using GeorgeShopAndRecipe.Core.Models.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeorgeShopAndRecipe.Controllers
{
    public class RecipeController : BaseController
    {
        [AllowAnonymous]
        public async  Task<IActionResult> All()
        {
            var model = new AllRecipesQueryModel();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new AllRecipesQueryModel();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new RecipeDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RecipeFormModel model)
        {
            return RedirectToAction(nameof(Details), new {id = 1});
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

        public async Task<IActionResult> Edit(RecipeDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }
    }
}
