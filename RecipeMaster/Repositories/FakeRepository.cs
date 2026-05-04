using RecipeMaster.Models;

namespace RecipeMaster.Repositories;

public class FakeRepository : IRecipeRepository
{
    private readonly List<Recipe> _recipes = new()
    {
        new Recipe { Id = 1, Name = "Omars Pasta", Description = "Världens bästa recept" }
    };

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await Task.FromResult(_recipes);
    }

    public async Task AddAsync(Recipe recipe)
    {
        // Vi räknar ut nästa ID och lägger till i listan
        recipe.Id = _recipes.Max(r => r.Id) + 1;
        _recipes.Add(recipe);
        await Task.CompletedTask;
    }
}