using Game.Model;
namespace Game.Repository
{
    public class FakeRepository : GameRepository
    {
        public async Task<IEnumerable<game>> GetallAsyinc() => new List <game>{ new game() };

        public async Task<game> GetIdAsyinc(int id) => new game { Id = id };

        public async Task<game> AddAsync(game game) 
        {
            return game;
        }



        public async Task UpdateAsync(game game) { }


        public async Task DeleteAsync (int id) { }

        public Task<game> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<game> DeleteAsync(game game)
        {
            throw new NotImplementedException();
        }
    }
}
