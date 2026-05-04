using Game.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Repositories
{
    public class FakeGameRepository : IGameRepository
    {
        // En statisk lista agerar som vår databas
        private static readonly List<Game.Models.Game> _games = new List<Game.Models.Game>();
        private static int _nextId = 1; // Håller koll på vilket ID nästa spel ska få

        public Task<IEnumerable<Game.Models.Game>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Game.Models.Game>>(_games);
        }

        public Task<Game.Models.Game> GetByIdAsync(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            return Task.FromResult(game);
        }

        public Task<Game.Models.Game> AddAsync(Game.Models.Game game)
        {
            game.Id = _nextId++; // Ge spelet ett unikt ID
            _games.Add(game);
            return Task.FromResult(game);
        }

        public Task<Game.Models.Game> UpdateAsync(Game.Models.Game game)
        {
            var existingGame = _games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame != null)
            {
                existingGame.Name = game.Name;
                existingGame.Description = game.Description;
                existingGame.Price = game.Price;
            }
            return Task.FromResult(existingGame);
        }

        public Task<Game.Models.Game> DeleteAsync(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game != null)
            {
                _games.Remove(game);
            }
            return Task.FromResult(game);
        }
    }
}