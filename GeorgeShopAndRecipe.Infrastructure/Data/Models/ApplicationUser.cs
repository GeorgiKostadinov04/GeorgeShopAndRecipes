using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GeorgeShopAndRecipe.Infrastructure.Data.Constants.DataConstants;

namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(ApplicationUserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(ApplicationUserLastNameMinLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty ;

        public RecipeDeveloper? RecipeDeveloper { get; set; } 
    }
}
