using GeorgeShopAndRecipe.Core.Models.RecipeDeveloper;
using GeorgeShopAndRecipe.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Core.Models.Recipe
{
    public class RecipeDetailsServiceModel : RecipeServiceModel
    {
        public string WayOfMaking { get; set; } = null!;

        public string Category { get; set; } = null!;

        public RecipeDeveloperServiceModel RecipeDeveloper { get; set; } = null!;

        public IEnumerable<string> IngredientsNames { get; set; } = new List<string>();

    }
}
