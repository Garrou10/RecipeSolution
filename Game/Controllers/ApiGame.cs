using Game.Model;
using Game.Repository;
using Game.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameservice _gameService;

        // Dependency Injection: Vi tar in servicen via konstruktorn
        public GamesController(IGameservice gameService)
        {
            _gameService = gameService;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game.Model.game>>> GetAll()
        {
            // ÄNDRAD: Matchar namnet i IGameservice
            var games = await _gameService.GetGameByAsyinc();
            return Ok(games);
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game.Model.game>> GetById(int id)
        {
            // ÄNDRAD: Matchar namnet i IGameservice
            var game = await _gameService.GetGameById(id);

            if (game == null)
            {
                return NotFound(); // 404
            }

            return Ok(game); // 200
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Game.Model.game>> Create(Game.Model.game newGame)
        {
            // Matchar namnet i IGameservice (Se till att du sparat IGameservice-filen!)
            var createdGame = await _gameService.CreateGameAsyic(newGame);

            return CreatedAtAction(nameof(GetById), new { id = createdGame.Id }, createdGame);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Game.Model.game updatedGame)
        {
            if (id != updatedGame.Id)
            {
                return BadRequest(); // 400 
            }

            // Matchar namnet i IGameservice
            var game = await _gameService.UpdateAsync(updatedGame);

            if (game == null)
            {
                return NotFound(); // 404 
            }

            return NoContent(); // 204 No Content 
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            // Matchar namnet i IGameservice
            var game = await _gameService.DeleteAsync(id);

            if (game == null)
            {
                return NotFound(); // 404 
            }

            return NoContent(); // 204 No Content
        }
    }
}