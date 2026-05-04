using RecipeMaster.Models;

namespace RecipeMaster.Services;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> GetAllRecipesAsync();
    Task<Recipe?> GetRecipeByIdAsync(int id);
    Task<Recipe> CreateRecipeAsync(Recipe recipe);
}