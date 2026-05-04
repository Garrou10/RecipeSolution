using GameManager.Models;

namespace GameManager.Repository
{
    public interface IGameRepository
    {
        Task <IEnumerable<Game>> GetAllAsync();
        Task <Game> GetByIdAsync (int id);
        Task <Game> AddAsync (Game game);
        Task DeleteAsync (int id); 
        Task UpdateAsync (Game game);
    }

 
}
