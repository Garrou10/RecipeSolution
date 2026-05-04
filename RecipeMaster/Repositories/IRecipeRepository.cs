using RecipeMaster.Models;

namespace RecipeMaster.Repositories
{
    public interface IRecipeRepository 
    {
        Task<IEnumerable<Recipe>> GetAllAsync();

        Task AddAsync(Recipe recipe);
    }
}
