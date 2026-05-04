using GameManager.Models;
using GameManager.Repository;
using System.Security.AccessControl;

namespace GameManager.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameservice;

        public GameService(IGameRepository gameservice) 
        {

            _gameservice = gameservice;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _gameservice.GetAllAsync();
        }

        public async Task<Game> GetGameIdAsync(int id)
        {
            return await _gameservice.GetByIdAsync(id);

        }

        public async Task<Game> AddGameAsync(Game game)
        {
            return await _gameservice.AddAsync(game);
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
             await _gameservice.UpdateAsync(game);
            return game;
        }

        public async Task DeleteGameAsync(int id)
        {
            await _gameservice.DeleteAsync(id);
        }

    }
}
