using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Infrastructure.Data.SeedDb
{
    internal class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            var data = new SeedData();

            builder.HasData(new Recipe[] {data.FirstRecipe, data.SecondRecipe});
        }
    }
}
