using Microsoft.AspNetCore.Mvc;
using RecipeApi.DTOs;
using RecipeApi.Services;

namespace RecipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        // Dependency Injection av Service-lagret
        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/recipes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes); // Returnerar 200 OK
        }

        // GET: api/recipes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound(new { message = $"Recept med ID {id} hittades inte." }); // Returnerar 404 Not Found
            }
            return Ok(recipe); // Returnerar 200 OK
        }

        
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            var recipes = await _recipeService.SearchRecipesAsync(q);
            return Ok(recipes); 
        }

        // GET: api/recipes/difficulty/{level}
        [HttpGet("difficulty/{level}")]
        public async Task<IActionResult> GetByDifficulty(string level)
        {
            var recipes = await _recipeService.GetRecipesByDifficultyAsync(level);
            return Ok(recipes);
        }

        // POST: api/recipes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecipeDto dto)
        {
   

            var createdRecipe = await _recipeService.CreateRecipeAsync(dto);


            return CreatedAtAction(nameof(GetById), new { id = createdRecipe.Id }, createdRecipe);
        }

        // PUT: api/recipes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateRecipeDto dto)
        {
            try
            {
                await _recipeService.UpdateRecipeAsync(id, dto);
                return NoContent(); // 204 No Content 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/recipes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _recipeService.DeleteRecipeAsync(id);
                return NoContent(); // 204 No Content 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}