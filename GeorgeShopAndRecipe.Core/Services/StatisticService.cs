using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Core.Models.Statistics;
using GeorgeShopAndRecipe.Infrastructure.Common;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<StatisticsServiceModel> TotalAsync()
        {
            int totalRecipes = await repository.AllReadOnly<Recipe>()
                .Where(r => r.IsApproved)
                .CountAsync();

            return new StatisticsServiceModel()
            {
                TotalRecipes = totalRecipes
            };
        }
    }
}
