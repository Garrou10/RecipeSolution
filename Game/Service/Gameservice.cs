using Game.Repository;
using Game.Model;
namespace Game.Service
{
    public class Gameservice : IGameservice
    {
        private readonly GameRepository _repository;

        public Gameservice (GameRepository repository)
        {
            _repository = repository;
        }

        public async  Task<IEnumerable<game>> GetGameByAsyinc()
        {
            return await _repository.GetallAsyinc();
        }

        public async Task<game> GetGameById(int id)
        {
            return await _repository.GetIdAsyinc(id);
        }

        public async Task<game> CreateGameAsyic(game game)
        {
            return await _repository.AddAsync(game);
        }

        public async Task<game> DeleteGameAsyic(int id)
        {
            return await _repository.UpdateAsync(id);
        }

        public async Task<game> UpdateGameAsyic(game game)
        { 
           return await _repository.DeleteAsync(game);
        }

    }
}
