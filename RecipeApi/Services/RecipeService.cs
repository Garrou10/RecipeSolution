using RecipeApi.DTOs;
using RecipeApi.Models;
using RecipeApi.Repositories;

namespace RecipeApi.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        // Dependency Injection av Repositoryt
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
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Recipe>> SearchRecipesAsync(string term)
        {
            // Retunera en tom lista direkt om sökordet saknas, 
            // så slipper vi ställa onödiga frågor till databasen.
            if (string.IsNullOrWhiteSpace(term))
                return new List<Recipe>();

            return await _repository.SearchAsync(term);
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByDifficultyAsync(string difficulty)
        {
            return await _repository.GetByDifficultyAsync(difficulty);
        }

        public async Task<Recipe> CreateRecipeAsync(CreateRecipeDto dto)
        {
            // Mappa DTO till den faktiska Domänmodellen. 
            // Detta är Service-lagrets huvuduppgift!
            var recipe = new Recipe
            {
                Name = dto.Name,
                Description = dto.Description,
                PrepTimeMinutes = dto.PrepTimeMinutes,
                CookTimeMinutes = dto.CookTimeMinutes,
                Servings = dto.Servings,
                Difficulty = dto.Difficulty,
                Instructions = dto.Instructions,
                Ingredients = dto.Ingredients.Select(i => new Ingredient
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Unit = i.Unit
                }).ToList()
            };

            // Skicka den mappade modellen till repositoryt för att sparas
            return await _repository.AddAsync(recipe);
        }

        public async Task UpdateRecipeAsync(int id, CreateRecipeDto dto)
        {
            // Kontrollera först om receptet vi vill uppdatera faktiskt finns
            var existingRecipe = await _repository.GetByIdAsync(id);
            if (existingRecipe == null)
            {
                // Om det inte finns, kasta ett fel. Controllern fångar detta och ger en 404 Not Found.
                throw new KeyNotFoundException($"Recept med ID {id} hittades inte.");
            }

            // Uppdatera värdena med det som kom in från DTO:n
            existingRecipe.Name = dto.Name;
            existingRecipe.Description = dto.Description;
            existingRecipe.PrepTimeMinutes = dto.PrepTimeMinutes;
            existingRecipe.CookTimeMinutes = dto.CookTimeMinutes;
            existingRecipe.Servings = dto.Servings;
            existingRecipe.Difficulty = dto.Difficulty;
            existingRecipe.Instructions = dto.Instructions;

            existingRecipe.Ingredients = dto.Ingredients.Select(i => new Ingredient
            {
                Name = i.Name,
                Quantity = i.Quantity,
                Unit = i.Unit
            }).ToList();

            // Spara ändringarna via repositoryt
            await _repository.UpdateAsync(existingRecipe);
        }

        public async Task DeleteRecipeAsync(int id)
        {
            // Kontrollera att receptet finns innan vi försöker ta bort det
            var existingRecipe = await _repository.GetByIdAsync(id);
            if (existingRecipe == null)
            {
                throw new KeyNotFoundException($"Recept med ID {id} hittades inte.");
            }

            await _repository.DeleteAsync(id);
        }
    }
}