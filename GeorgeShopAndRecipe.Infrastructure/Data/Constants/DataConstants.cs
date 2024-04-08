using System;
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

        //Shop
        public const int ShopNameMaxLength = 20;
        public const int ShopNameMinLength = 2;

        //Supplier
        public const int SupplierFirstNameMaxLength = 50;
        public const int SupplierFirstNameMinLength = 4;
        public const int SupplierLastNameMaxLength = 50;
        public const int SupplierLastNameMinLength = 4;
        public const int SupplierAgeMaxValue = 99;
        public const int SupplierAgeMinValue = 18;
        public const double SupplierRatingMinValue = 0;
        public const double SupplierRatingMaxValue = 5;

        //RecipeDeveloper
        public const int RecipeDeveloperNameMaxLength = 50;
        public const int RecipeDeveloperNameMinLength = 3;

        //ApplicationUser
        public const int ApplicationUserFirstNameMaxLength = 50;
        public const int ApplicationUserFirstNameMinLength = 1;
        public const int ApplicationUserLastNameMaxLength = 50;
        public const int ApplicationUserLastNameMinLength = 10;
    }
}
