namespace GeorgeShopAndRecipe.Core.Contracts
{
    public interface IRecipeDeveloperService
    {
        Task<bool> ExistByIdAsync(string userId);

        Task CreateAsync(string userId, string name);

        Task<int?> GetRecipeDeveloperId(string userId);
    }
}
