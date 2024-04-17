using GeorgeShopAndRecipe.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IRecipeModel recipe)
        {
            string info = recipe.Name.Replace(" ", "-");
            info = Regex.Replace(info, @"[^a-z-A-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
