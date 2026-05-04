using RecipeApi.Models;

namespace RecipeApi.Repositories
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe?> GetByIdAsync(int id);
        Task<IEnumerable<Recipe>> SearchAsync(string term);
        Task<IEnumerable<Recipe>> GetByDifficultyAsync(string difficulty);
        Task<Recipe> AddAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(int id);
    }
}