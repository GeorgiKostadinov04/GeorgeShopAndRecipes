using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Services;
using GeorgeShopAndRecipe.Infrastructure.Common;
using GeorgeShopAndRecipe.Infrastructure.Data;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Security.Cryptography.Xml;

namespace GeorgeShopAndRecipe.UnitTesting;

[TestFixture]
public class RecipeUnitTests
{
    private IRepository repository;
    private IRecipeService recipeService;
    private ApplicationDbContext applicationDbContext;
    private Mock<UserManager<ApplicationUser>> mockUserManager;

    [SetUp]
    public void SetUp()
    {
        var mockUserStore = new Mock<UserManager<ApplicationUser>>();
        mockUserManager = new Mock<UserManager<ApplicationUser>>(mockUserStore.Object, 
            null, null, null, null, null, null, null, null);

        mockUserManager.Setup(x => x.IsInRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync((ApplicationUser user, string role) => role == "Admin");

        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<RecipeUnitTests>()
            .Build();

        var connectionString = configuration.GetConnectionString("TestConnection");

        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        applicationDbContext = new ApplicationDbContext(contextOptions);
        repository = new Repository(applicationDbContext);
        recipeService = new RecipeService(repository, mockUserManager.Object);

        applicationDbContext.Database.EnsureDeleted();
        applicationDbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task TestGetRecipeFormModelByIdAsyncMethod()
    {
        var recipe = await repository.All<Recipe>()
            .Include(r => r.IngredientsRecipes)
            .FirstOrDefaultAsync();

        Assert.That(recipe, Is.Not.Null, "Movie is not null");

        var recipeForm = await recipeService.GetRecipeFormModelByIdAsync(recipe.Id);

        Assert.That(recipeForm.Name, Is.EqualTo(recipe.Name));
        Assert.That(recipeForm.WayOfMaking, Is.EqualTo(recipe.WayOfMaking));
        Assert.That(recipeForm.ImageUrl, Is.EqualTo(recipe.ImageUrl));
        Assert.That(recipeForm.CategoryId, Is.EqualTo(recipe.CategoryId));
    }

    [Test]
    public async Task TestApproveRecipeAsyncMethod()
    {
        Recipe recipe = new Recipe()
        {
            Id = 11,
            Name = "Recipe name",
            WayOfMaking = "Recipe way of making",
            ImageUrl = "Image Url",
            CategoryId = 2,
            RecipeDeveloperId = 2,
            IsApproved = false,
        };

       recipeService.ApproveRecipeAsync(11);


        Assert.That(recipe.IsApproved, Is.True);

    }
} 

