using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Infrastructure.Common;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using GeorgeShopAndRecipe.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Services;
using GeorgeShopAndRecipe.Core.Models.Statistics;

namespace GeorgeShopAndRecipe.Services.Tests
{
    [TestFixture]
    public class StatisticTests
    {
        private IRepository repository;
        private IStatisticService service;
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
        public async Task StatisticsTotalAsyncMethodShouldReturnTheRightType()
        {
            repository = new Repository(context);
            service = new StatisticService(repository);

            StatisticsServiceModel goal = new StatisticsServiceModel();

            var result = await service.TotalAsync();

            Assert.That(result.GetType(), Is.EqualTo(goal.GetType()));
        }

        [Test]
        public async Task StatisticsTotalAsyncMethodShouldWorkProperly()
        {
            repository = new Repository(context);
            service = new StatisticService(repository);

            var result = await service.TotalAsync();

            var count = result.TotalRecipes;
            //Seeded in the database
            Assert.That(count, Is.EqualTo(2));
        }
    }
}
