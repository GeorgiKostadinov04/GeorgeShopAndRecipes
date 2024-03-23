namespace GeorgeShopAndRecipe.Core.Contracts
{
    public interface IRecipeDeveloperService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task<bool> UserWithNameExistsAsync(string name);

        Task CreateAsync(string userId, string name);
    }
}
