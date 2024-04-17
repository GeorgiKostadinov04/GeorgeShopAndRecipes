using GeorgeShopAndRecipe.Attributes;
using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Models.RecipeDeveloper;
using GeorgeShopAndRecipe.Extensions;
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
        [NotARecipeDeveloper]
        public IActionResult Become()
        {
            var model = new BecomeRecipeDeveloperFormModel();

            return View(model);
        }

        [HttpPost]
        [NotARecipeDeveloper]
        public async Task<IActionResult> Become(BecomeRecipeDeveloperFormModel model)
        {
            if(ModelState.IsValid == false)
            {
                return View(model); 
            }

            await recipeDeveloperService.CreateAsync(User.Id(), model.Name);

            return RedirectToAction(nameof(RecipeController.All), "Recipe");
        }
    }
}
