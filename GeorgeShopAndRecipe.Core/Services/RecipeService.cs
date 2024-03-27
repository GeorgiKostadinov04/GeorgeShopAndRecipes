using GeorgeShopAndRecipe.Core.Contracts.Recipe;
using GeorgeShopAndRecipe.Core.Models.Home;
using GeorgeShopAndRecipe.Core.Models.Recipe;
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
    public class RecipeService : IRecipeService
    {
        private readonly IRepository repository;

        public RecipeService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<RecipeCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new RecipeCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RecipeIngredientServiceModel>> AllIngredientsAsync()
        {
            return await repository.AllReadOnly<Ingredient>()
                .Select(i => new RecipeIngredientServiceModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                })
                .ToListAsync();
        }

        public Task<bool> CategoryExistsAsync(int categoryId)
        {
            return repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(RecipeFormModel model, int recipeDeveloperId)
        {
            Recipe recipe = new Recipe()
            {
                Name = model.Name,
                RecipeDeveloperId = recipeDeveloperId,
                WayOfMaking = model.WayOfMaking,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,

            };

            await repository.AddAsync(recipe);
            await repository.SaveChangesAsync();

            return recipe.Id;
        }

        public Task<bool> IngredientExistsAsync(string ingredientName)
        {
            return repository.AllReadOnly<Ingredient>()
                .AnyAsync(i=> i.Name == ingredientName);
        }

        public async Task<IEnumerable<RecipeIndexServiceModel>> LastThreeRecipesAsync()
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
