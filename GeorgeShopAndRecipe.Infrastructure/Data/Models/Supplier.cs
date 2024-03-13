using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;
namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SupplierFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(SupplierLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Range(SupplierAgeMinValue,SupplierAgeMaxValue)]
        public int Age { get; set; }

        [Range(SupplierRatingMinValue, SupplierRatingMaxValue)]
        public double Rating { get; set; }
    }
}