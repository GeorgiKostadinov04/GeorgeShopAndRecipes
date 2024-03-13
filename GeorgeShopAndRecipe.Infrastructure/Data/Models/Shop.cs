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
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^\\+359[7-9][0-9]{8}$")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [Required]
        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
