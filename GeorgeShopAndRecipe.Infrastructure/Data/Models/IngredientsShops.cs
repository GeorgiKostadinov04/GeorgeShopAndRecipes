using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Infrastructure.Data.Models
{
    public class IngredientsShops
    {
        [Required]
        public int IngredientId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; } = null!;

        [Required]
        public int ShopId { get; set; }

        [ForeignKey(nameof(ShopId))]
        public Shop Shop { get; set; } = null!;
    }
}
