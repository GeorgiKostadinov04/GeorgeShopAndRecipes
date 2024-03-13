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
        public string Name { get; set; } = string.Empty;

        [Required]
        public double Calories { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(IngredientCategoryMaxLength)]
        public string Category { get; set; } = string.Empty;
    }
}