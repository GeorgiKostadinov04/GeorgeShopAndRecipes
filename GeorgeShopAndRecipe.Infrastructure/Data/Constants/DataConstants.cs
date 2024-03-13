﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Infrastructure.Data.Constants
{
    public class DataConstants
    {
        //Recipe
        public const int RecipeNameMaxLength = 50;
        public const int RecipeNameMinLength = 7;
        public const int RecipeWayOfMakingMaxLength = 300;
        public const int RecipeWayOfMakingMinLength = 20;

        //Category
        public const int CategoryNameMaxLength = 30;
        public const int CategoryNameMinLength = 5;

        //Ingredient
        public const int IngredientNameMaxLength = 50;
        public const int IngredientNameMinLength = 3;
        public const int IngredientCategoryMaxLength = 20;
        public const int IngredientCategoryMinLength = 3;
    }
}