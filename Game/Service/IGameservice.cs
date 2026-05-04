using Game.Model;
namespace Game.Service
{
    public interface IGameservice

    {
        Task<IEnumerable<game>> GetGameByAsyinc();
        Task <game> GetGameById(int id);
        Task <game> CreateGameAsyic (game game);

        Task<game> DeleteGameAsyic (int id);


        Task<game> UpdateGameAsyic(game game);




    }
}
