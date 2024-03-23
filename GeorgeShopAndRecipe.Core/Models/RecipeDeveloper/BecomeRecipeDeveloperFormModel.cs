using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Core.Constants.MessageConstants;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;

namespace GeorgeShopAndRecipe.Core.Models.RecipeDeveloper
{
    public class BecomeRecipeDeveloperFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(RecipeDeveloperNameMaxLength, MinimumLength = RecipeDeveloperNameMinLength
            ,ErrorMessage = LengthMessage)]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
    }
}
