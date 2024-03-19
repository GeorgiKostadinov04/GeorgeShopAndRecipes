using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;
namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    public class Shop
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ShopNameMaxLength)]
        [Comment("Shop name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^\\+359[7-9][0-9]{8}$")]
        [Comment("Shop phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Shop image url")]
        public string ImageUrl { get; set; } = string.Empty;


        public ICollection<IngredientsShops> IngredientsShops { get; set; }

    }
}
