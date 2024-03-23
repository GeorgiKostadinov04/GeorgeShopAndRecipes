using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Models.RecipeDeveloper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeorgeShopAndRecipe.Controllers
{
    [Authorize]
    public class RecipeDeveloperController : BaseController
    {
        private readonly IRecipeDeveloperService recipeDeveloperService;

        public RecipeDeveloperController(IRecipeDeveloperService _recipeDeveloperService)
        {
            recipeDeveloperService = _recipeDeveloperService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var model = new BecomeRecipeDeveloperFormModel();
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Become(BecomeRecipeDeveloperFormModel model)
        {
            return RedirectToAction(nameof(RecipeController.All), "Recipe");
        }
    }
}
