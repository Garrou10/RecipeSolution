using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeMaster.Models;
using RecipeMaster.Services;

namespace RecipeMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase // 1. Använd plural "Recipes"
    {
        private readonly IRecipeService _service;

        // 2. Namnet här MÅSTE matcha klassnamnet ovanför exakt
        public RecipesController(IRecipeService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Recipe>>> GetAll()
        {
           var recipe = await _service.GetAllRecipesAsync();
            return Ok(recipe);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Recipe>> GetById(int id) {
                

            var recipe = await _service.GetRecipeByIdAsync (id);

            if (recipe == null) 
                return NotFound();
            return Ok(recipe);


        }
    }
}
