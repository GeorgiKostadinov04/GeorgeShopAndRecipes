using GeorgeShopAndRecipe.Core.Contracts;
using GeorgeShopAndRecipe.Infrastructure.Common;
using GeorgeShopAndRecipe.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GeorgeShopAndRecipe.Core.Services
{
    public class RecipeDeveloperService : IRecipeDeveloperService
    {
        private readonly IRepository repository;

        public RecipeDeveloperService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string name)
        {
            await repository.AddAsync(new RecipeDeveloper { UserId = userId, Name = name });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<RecipeDeveloper>()
                .AnyAsync(rd=>rd.UserId == userId);
        }

        public async Task<int?> GetRecipeDeveloperIdAsync(string userId)
        {
            return (await repository.AllReadOnly<RecipeDeveloper>()
                .FirstOrDefaultAsync(rd =>rd.UserId == userId))?.Id;
        }
    }
}
