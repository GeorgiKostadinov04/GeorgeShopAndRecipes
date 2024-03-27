namespace GeorgeShopAndRecipe.Core.Models.Recipe
{
    public class RecipeServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string WayOfMaking { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}