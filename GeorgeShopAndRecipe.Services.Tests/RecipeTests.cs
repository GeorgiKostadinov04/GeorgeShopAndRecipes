using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Models.Recipe;
using GeorgeShopAndRecipe.Core.Services;
using GeorgeShopAndRecipe.Infrastructure.Common;
using GeorgeShopAndRecipe.Infrastructure.Data;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Services.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        private IRepository repository;
        private IRecipeService service;
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext context;



        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("RecipeDB")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task RecipeAllAsyncMethodShouldReturnTheRightType()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            var goal = new RecipeQueryServiceModel();

            var result = await service.AllAsync();

            Assert.That(result.GetType(), Is.EqualTo(goal.GetType()));
        }

        [Test]

        public async Task RecipeAllAsyncMethodShouldReturnRecipesCountCorrectly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                CategoryId = 1,
                IsApproved = true,
            });
            await repository.SaveChangesAsync();

            var result = await service.AllAsync();

            var goal = result.TotalRecipesCount;
            
            
            Assert.That(goal, Is.EqualTo(3));
        }

        [Test]

        public async Task RecipeAllAsyncMethodShouldReturnRecipesCorrectly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                CategoryId = 1,
                IsApproved = true,
            });

            await repository.SaveChangesAsync();

            var result = await service.AllAsync();

            var goal = result.Recipes.Count();

            Assert.That(goal, Is.EqualTo(1));
        }

        [Test]

        public async Task RecipeAllCategoriesAsyncMethodShouldWorkCorrectly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);
            
            var result = await service.AllCategoriesAsync();
            
            int count = result.Count();
            //6 category seeded in the database
            Assert.That(count, Is.EqualTo(6));

        }

        [Test]

        public async Task RecipeAllIngredientsAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            var result = await service.AllIngredientsAsync();

            int count = result.Count(); 
            //22 ingredients seeded in the database
            Assert.That(count, Is.EqualTo(22));
        }

        [Test]

        public async Task AllRecipesByRecipeDeveloperIdAsyncMethodShouldWorkCorrectly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                RecipeDeveloperId = 2,
                IsApproved = true
            });

            await repository.SaveChangesAsync();

            var result = await service.AllRecipesByRecipeDeveloperIdAsync(2);

            int count = result.Count();

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public async Task ApproveRecipeAsyncMethodShouldWorkCorrectly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                RecipeDeveloperId = 2,
                IsApproved = false
            });

            await repository.SaveChangesAsync();

            await service.ApproveRecipeAsync(5);

            var recipe = await repository.GetByIdAsync<Recipe>(5);

            Assert.That(recipe.IsApproved, Is.True);

            
        }

        [Test]
        public async Task CategoryExistsAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            //Seeded into database
            bool result = await service.CategoryExistsAsync(1);

            Assert.That(result, Is.True);
        }

        [Test]

        public async Task RecipeCreateAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            RecipeFormModel model = new RecipeFormModel()
            {
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                CategoryId = 1,

            };
            int recipeDevId = 2;

            int recipeId = await service.CreateAsync(model, recipeDevId);

            var recipe = await repository.GetByIdAsync<Recipe>(recipeId);

            Assert.That(recipe, Is.Not.Null);
        }

        [Test]
        public async Task RecipeDeleteAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            RecipeFormModel model = new RecipeFormModel()
            {
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                CategoryId = 1,

            };
            int recipeDevId = 2;

            int recipeId = await service.CreateAsync(model, recipeDevId);

            await service.DeleteAsync(recipeId);

            var count = repository.AllReadOnly<Recipe>().Count();
            //2 recipes seeded into database
            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task RecipeEditAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                RecipeDeveloperId = 2,
                IsApproved = true
            });

            RecipeFormModel model = new RecipeFormModel()
            {
                Name = "test",
                WayOfMaking = "test",
                ImageUrl = "test",
                CategoryId = 1,
            };

            await service.EditAsync(5, model);

            var recipe = await repository.GetByIdAsync<Recipe>(5);

            Assert.That(recipe.Name, Is.EqualTo("test"));
            Assert.That(recipe.WayOfMaking, Is.EqualTo("test"));
            Assert.That(recipe.ImageUrl, Is.EqualTo("test"));
            Assert.That(recipe.CategoryId, Is.EqualTo(1));
        }

        [Test]

        public async Task RecipeExistsAsyncMethodShouldWorkCorrectly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            bool result = await service.ExistsAsync(1);
            //Seeded into database
            Assert.That(result, Is.True);
        }

        [Test]

        public async Task GetRecipeFormModelByIdAsyncMethodShouldNotReturnNull()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            RecipeFormModel? result = await service.GetRecipeFormModelByIdAsync(1);
            //Seeded recipes in the database
            Assert.That(result, Is.Not.Null);
        }

        [Test]

        public async Task GetRecipeFormModelByIdAsyncMethodShouldLoadCategoriesAndIngredients()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            RecipeFormModel? result = await service.GetRecipeFormModelByIdAsync(1);
            //Seeded recipes in the database
            Assert.That(result.Ingredients, Is.Not.Null);
            Assert.That(result.Categories, Is.Not.Null);
        }

        [Test]

        public async Task RecipeGetUnApprovedAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                RecipeDeveloperId = 2,
                IsApproved = false
            });

            await repository.SaveChangesAsync();

            IEnumerable<RecipeServiceModel> result = await service.GetUnApprovedAsync();

            int count = result.Count();

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public async Task HasRecipeDeveloperWithIdAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new RecipeDeveloper
            {
                Id = 5,
                Name = "",
                UserId = "test"
            });

            await repository.SaveChangesAsync();

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                RecipeDeveloperId = 5,
                IsApproved = false
            });

            await repository.SaveChangesAsync();

            bool result = await service.HasRecipeDeveloperWithIdAsync(5, "test");

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task RecipeIngredientExistsAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            bool result = await service.IngredientExistsAsync("Fish");

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task LastThreeRecipesAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "",
                WayOfMaking = "",
                ImageUrl = "",
                RecipeDeveloperId = 5,
                IsApproved = true
            });

            await repository.SaveChangesAsync();

            var result = await service.LastThreeRecipesAsync();

            var count = result.Count();
            //2 recipes seeded into database
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public async Task RecipeDetailsByIdAsync()
        {
            repository = new Repository(context);
            service = new RecipeService(repository, userManager);
            await repository.AddAsync(new RecipeDeveloper
            {
                Id = 5,
                Name = "Grigor",
                UserId = "test"
            });

            await repository.SaveChangesAsync();

            await repository.AddAsync(new Recipe
            {
                Id = 5,
                Name = "test",
                WayOfMaking = "test",
                ImageUrl = "test",
                RecipeDeveloperId = 5,
                IsApproved = true,
                CategoryId = 3
            });

            await repository.SaveChangesAsync();

            
            var result = await service.RecipeDetailsByIdAsync(5);

            Assert.That(result.Name, Is.EqualTo("test"));
            Assert.That(result.WayOfMaking, Is.EqualTo("test"));
            Assert.That(result.ImageUrl, Is.EqualTo("test"));
            Assert.That(result.Id, Is.EqualTo(5));
            Assert.That(result.Category, Is.EqualTo("High protein"));
            Assert.That(result.RecipeDeveloper.Name, Is.EqualTo("Grigor"));
        }
    }

}
