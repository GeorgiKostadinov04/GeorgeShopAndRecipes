﻿using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Core.Constants.MessageConstants;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;


namespace GeorgeShopAndRecipe.Core.Models.Recipe

{
    public class RecipeFormModel : IRecipeModel
    {
        [Required(ErrorMessage =RequiredMessage)]
        
        [StringLength(RecipeNameMaxLength,
            MinimumLength = RecipeNameMinLength,
            ErrorMessage = SymbolMessage)]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage =RequiredMessage)]
        [StringLength(RecipeWayOfMakingMaxLength, MinimumLength = RecipeWayOfMakingMinLength,
            ErrorMessage = SymbolMessage)]
        [Display(Name = "Way of making")]
        public string WayOfMaking { get; set; } = null!;

        [Required(ErrorMessage =RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name= "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<RecipeCategoryServiceModel> Categories { get; set; } = new List<RecipeCategoryServiceModel>();

        [Display(Name = "All Ingredients")]
        public IEnumerable<RecipeIngredientServiceModel> Ingredients { get; set; } = new List<RecipeIngredientServiceModel>();


    }
}
