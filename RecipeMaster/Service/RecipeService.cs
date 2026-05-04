using RecipeMaster.Models;
using RecipeMaster.Repositories;

namespace RecipeMaster.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;

    // Dependency Injection: Vi ger kocken tillgång till skafferiet (Repository)
    public RecipeService(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Recipe?> GetRecipeByIdAsync(int id)
    {
        var recipes = await _repository.GetAllAsync();
        return recipes.FirstOrDefault(r => r.Id == id);
    }

    public async Task<Recipe> CreateRecipeAsync(Recipe recipe)
    {
        // Här kan vi lägga logik, t.ex. kolla om namnet är tomt
        await _repository.AddAsync(recipe);
        return recipe;
    }
}