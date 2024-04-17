using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Services;
using GeorgeShopAndRecipe.Infrastructure.Common;
using GeorgeShopAndRecipe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Services.Tests
{
    [TestFixture]
    public class UserTests
    {
        private IRepository repository;
        private IUserService service;
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

        public async Task UserAllAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new UserService(repository);

            var result = await service.AllAsync();

            var count = result.Count();

            Assert.That(count, Is.Not.NaN);
        }

        [Test]

        public async Task UserFullNameAsyncShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new UserService(repository);
            
            string userId = "299e94d7-1a68-4738-9d25-e062394ae0c5";

            string result = await service.UserFullNameAsync(userId);
            //Seeded in the database
            Assert.That(result, Is.EqualTo("Great Admin"));
        }
    }
}
