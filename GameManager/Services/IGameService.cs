using GameManager.Models;
using GameManager.Repository;
namespace GameManager.Services
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();

        Task<Game> GetGameIdAsync(int id);

        Task<Game> AddGameAsync(Game game);

        Task<Game> UpdateGameAsync(Game game);

        Task DeleteGameAsync(int id);   
    }
}
