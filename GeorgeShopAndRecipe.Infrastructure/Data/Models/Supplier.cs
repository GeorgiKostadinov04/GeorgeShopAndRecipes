using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;
namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SupplierFirstNameMaxLength)]
        [Comment("Supplier first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(SupplierLastNameMaxLength)]
        [Comment("Supplier last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Range(SupplierAgeMinValue,SupplierAgeMaxValue)]
        [Comment("Supplier age")]
        public int Age { get; set; }

        [Range(SupplierRatingMinValue, SupplierRatingMaxValue)]
        [Comment("Supplier rating")]
        public double Rating { get; set; }

        [Required]
        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;
    }
}