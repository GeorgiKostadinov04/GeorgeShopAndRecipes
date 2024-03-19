using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using GeorgeShopAndRecipe.Infrastructure.Data.SeedDb;
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

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<RecipeDeveloper> RecipeDevelopers { get; set; }

        public DbSet<IngredientsShops> IngredienstShops { get; set; }

        public DbSet<IngredientsRecipes> IngredientsRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<IngredientsShops>()
                .HasKey(x => new { x.ShopId, x.IngredientId });

            builder.Entity<IngredientsRecipes>()
                .HasKey(x => new { x.RecipeId, x.IngredientId });

            builder.Entity<IngredientsRecipes>()
                .HasOne(x => x.Ingredient)
                .WithMany(y => y.IngredientsRecipes)
                .HasForeignKey(x => x.IngredientId);

            builder.Entity<IngredientsRecipes>()
                .HasOne(x=> x.Recipe)
                .WithMany(y => y.IngredientsRecipes)
                .HasForeignKey(x => x.RecipeId);

            builder.Entity<IngredientsShops>()
                .HasOne(x => x.Ingredient)
                .WithMany(y => y.IngredientsShops)
                .HasForeignKey(x => x.IngredientId);

            builder.Entity<IngredientsShops>()
                .HasOne(x => x.Shop)
                .WithMany(y => y.IngredientsShops)
                .HasForeignKey(x => x.ShopId);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RecipeConfiguration());
            builder.ApplyConfiguration(new RecipeDeveloperConfiguration());
            builder.ApplyConfiguration(new ShopConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new IngredientConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
