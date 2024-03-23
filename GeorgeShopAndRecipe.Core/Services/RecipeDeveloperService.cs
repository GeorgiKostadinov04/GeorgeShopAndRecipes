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

        public Task CreateAsync(string userId, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<RecipeDeveloper>()
                .AnyAsync(rd=>rd.UserId == userId);
        }

        public Task<bool> UserWithNameExistsAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
