using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Models.Home;
using GeorgeShopAndRecipe.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgeShopAndRecipe.Core.Services.Recipe
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository repository;

        public RecipeService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<RecipeIndexServiceModel>> LastThreeRecipes()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Recipe>()
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new RecipeIndexServiceModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync();
        }
    }
}
