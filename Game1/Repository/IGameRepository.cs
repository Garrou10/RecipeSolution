using Game.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Game.Repository
{
    // Kom ihåg: Ett Interface börjar ALLTID med ett stort I
    public interface IGameRepository
    {
        Task<IEnumerable<Game.Model.Game>> GetAllAsync();
        Task<Game.Model.Game> GetByIdAsync(int id);
        Task<Game.Model.Game> AddAsync(Game.Model.Game game);
        Task<Game.Model.Game> UpdateAsync(Game.Model.Game game);
        Task<Game.Model.Game> DeleteAsync(int id);
    }
}