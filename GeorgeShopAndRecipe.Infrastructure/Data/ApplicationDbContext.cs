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

        public DbSet<RecipeDeveloper> RecipeDevelopers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
