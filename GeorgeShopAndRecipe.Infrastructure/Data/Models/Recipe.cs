using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;
namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    public class Recipe
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RecipeNameMaxLength)]
        [Comment("Recipe name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(RecipeWayOfMakingMaxLength)]
        [Comment("Recipe way of making")]
        public string WayOfMaking { get; set; } = string.Empty;

        [Required]
        public int CategoryId {  get; set; }
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Recipe image url")]
        public string ImageUrl {  get; set; } = string.Empty;

        [Comment("Is a recipe approved by admin")]
        public bool IsApproved { get; set; }

        [Required]
        
        public int RecipeDeveloperId { get; set; }

        [ForeignKey(nameof(RecipeDeveloperId))]
        public RecipeDeveloper RecipeDeveloper { get; set; } = null!;

        
        public ICollection<IngredientsRecipes> IngredientsRecipes { get; set; } 
    }
}
