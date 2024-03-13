using Microsoft.AspNetCore.Identity;
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
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(RecipeWayOfMakingMaxLength)]
        public string WayOfMaking { get; set; } = string.Empty;

        [Required]
        
        public string PublisherId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        public string CategoryId {  get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
