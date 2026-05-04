using RecipeApi.Models;

namespace RecipeApi.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        // Simulerar en databas med en in-memory lista
        private readonly List<Recipe> _recipes = new();
        private int _nextId = 1;

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await Task.FromResult(_recipes);
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            return await Task.FromResult(recipe);
        }

        public async Task<IEnumerable<Recipe>> SearchAsync(string term)
        {
            var result = _recipes.Where(r =>
                r.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                r.Description.Contains(term, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<Recipe>> GetByDifficultyAsync(string difficulty)
        {
            var result = _recipes.Where(r =>
                r.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(result);
        }

        public async Task<Recipe> AddAsync(Recipe recipe)
        {
            recipe.Id = _nextId++;
            recipe.CreatedAt = DateTime.UtcNow;
            _recipes.Add(recipe);

            return await Task.FromResult(recipe);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            var index = _recipes.FindIndex(r => r.Id == recipe.Id);
            if (index != -1)
            {
                _recipes[index] = recipe;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            if (recipe != null)
            {
                _recipes.Remove(recipe);
            }
            await Task.CompletedTask;
        }
    }
}