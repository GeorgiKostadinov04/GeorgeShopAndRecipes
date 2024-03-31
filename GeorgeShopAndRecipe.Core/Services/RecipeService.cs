﻿using GeorgeShopAndRecipe.Core.Contracts.Recipe;
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

        public async Task<RecipeQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, int currentPage = 1, int recipesPerPage = 1)
        {
            var recipesToShow = repository.AllReadOnly<Recipe>();

            if(category != null)
            {
                recipesToShow = recipesToShow.Where(r =>r.Category.Name == category);
            }

            if(searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                recipesToShow = recipesToShow.Where(r => (r.Name.ToLower().Contains(normalizedSearchTerm)
                || r.WayOfMaking.ToLower().Contains(normalizedSearchTerm)));
            }

            var recipes = await recipesToShow
                .Skip((currentPage - 1) * recipesPerPage)
                .Take(recipesPerPage)
                .Select(r => new RecipeServiceModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    WayOfMaking = r.WayOfMaking,
                    ImageUrl = r.ImageUrl,
                })
                .ToListAsync();

            int totalRecipes = await recipesToShow.CountAsync();

            return new RecipeQueryServiceModel()
            {
                Recipes = recipes,
                TotalRecipesCount = totalRecipes
            };
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

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
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
