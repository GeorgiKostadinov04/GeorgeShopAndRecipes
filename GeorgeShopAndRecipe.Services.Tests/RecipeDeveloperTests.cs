using Castle.Core.Logging;
using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Services;
using GeorgeShopAndRecipe.Infrastructure.Common;
using GeorgeShopAndRecipe.Infrastructure.Data;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;


namespace GeorgeShopAndRecipe.Services.RecipeDeveloperTests
{
    [TestFixture]
    public class RecipeDeveloperTests
    {
        private IRepository repository;
        private IRecipeDeveloperService service;
        private ApplicationDbContext context;
 


        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("RecipeDeveloperDB")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task RecipeDeveloperExistsByIdAsyncShouldReturnTrueIfExist()
        {
            repository = new Repository(context);
            service = new RecipeDeveloperService(repository);
            string userId = "299e94d7-1a68-4738-9d25-e062394ae0c5";
            await repository.AddAsync(new RecipeDeveloper
            {
                Id = 1,
                Name = "gosho",
                UserId = userId
            });
            
            bool trueOrFalse = await service.ExistByIdAsync(userId);

            Assert.That(trueOrFalse, Is.True);
        }

        [Test]

        public async Task RecipeDeveloperCreateAsyncMethodShouldCreateProperly()
        {
            repository = new Repository(context);
            service = new RecipeDeveloperService(repository);

            string userId = "299e94d7-1a68-4738-9d25-e062394ae0c5";
            string name = "Georgi";

            await service.CreateAsync(userId, name);

            var doesExist = repository.GetByIdAsync<RecipeDeveloper>(1);

            Assert.That(doesExist, Is.Not.Null);
        }

        [Test]

        public async Task GetRecipeDeveloperIdAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new RecipeDeveloperService(repository);

            await service.CreateAsync("test", "Ivan");
            
            int? result = await service.GetRecipeDeveloperIdAsync("test");

            Assert.That(result, Is.Not.Null);
        }

    }
}