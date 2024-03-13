using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeorgeShopAndRecipe.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Ingredient> Ingredients { get; set;}

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Gluten free"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Vegetarian"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Vegan"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Dairy free"
                },
                new Category()
                {
                    Id = 5,
                    Name = "High protein"
                },
                new Category()
                {
                    Id = 6,
                    Name = "None"
                });


            base.OnModelCreating(builder);
        }
    }
}
