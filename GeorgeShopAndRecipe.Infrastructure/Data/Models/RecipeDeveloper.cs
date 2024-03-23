using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;

namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    
    public class RecipeDeveloper
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RecipeDeveloperNameMaxLength)]
        [Comment("Recipe developer's name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
