using Game.Model;
namespace Game.Repository
{
    public interface GameRepository
    {
        Task<IEnumerable<game>> GetallAsyinc();
        Task <game> GetIdAsyinc (int id);
        Task <game> AddAsync (game game);
        Task  UpdateAsync (game game);
        Task  DeleteAsync (int id);
        Task<game> UpdateAsync(int id);
        Task<game> DeleteAsync(game game);
    }
}
