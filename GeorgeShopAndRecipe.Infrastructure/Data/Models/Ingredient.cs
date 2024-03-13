using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;

namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(IngredientNameMaxLength)]
        [Comment("Ingredient name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Ingredient calories")]
        public double Calories { get; set; }

        [Required]
        [Comment("Ingredient price")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(IngredientCategoryMaxLength)]
        [Comment("Ingredient category")]
        public string Category { get; set; } = string.Empty;

        [Required]
        public DateTime ExpireDate { get; set; }

        [Required]
        [Comment("Ingredient image url")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}