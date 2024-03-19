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
    internal class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            

            var data = new SeedData();

            builder.HasData(new Shop[] {data.FirstShop});
        }
    }
}
