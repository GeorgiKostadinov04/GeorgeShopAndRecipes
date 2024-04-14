using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Infrastructure.Data.SeedDb
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {

            var data = new SeedData();

            builder.HasData(new Ingredient[] 
            {
                data.FirstIngredient, data.SecondIngredient, 
                data.ThirdIngredient, data.FourthIngredient,
                data.FifthIngredient, data.SixthIngredient,
                data.SeventhIngredient, data.EigthIngredient,
                data.NinthIngredient, data.TenthIngredient,
                data.ElevenIngredient, data.TwelveIngredient
            });
        }
    }
}
