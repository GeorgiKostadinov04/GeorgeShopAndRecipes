using GeorgeShopAndRecipe.Core.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Core.Models.Admin
{
    public class MyRecipesViewModel
    {
        public IEnumerable<RecipeServiceModel> AddedRecipes { get; set; } = new List<RecipeServiceModel>();
    }
}
