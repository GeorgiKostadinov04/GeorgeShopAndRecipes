using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Models.Home;
using GeorgeShopAndRecipe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeorgeShopAndRecipe.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecipeService recipeService;

        public HomeController(ILogger<HomeController> logger, IRecipeService _recipeService)
        {
            _logger = logger;
            recipeService = _recipeService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await recipeService.LastThreeRecipes();
            return View(model);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
