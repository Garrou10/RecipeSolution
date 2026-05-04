using RecipeApi.DTOs;
using RecipeApi.Models;


namespace RecipeApi.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe?> GetRecipeByIdAsync(int id);
        Task<IEnumerable<Recipe>> SearchRecipesAsync(string term);
        Task<IEnumerable<Recipe>> GetRecipesByDifficultyAsync(string difficulty);
        Task<Recipe> CreateRecipeAsync(CreateRecipeDto dto);
        Task UpdateRecipeAsync(int id, CreateRecipeDto dto);
        Task DeleteRecipeAsync(int id);
    }
}