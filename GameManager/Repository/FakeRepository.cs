using GameManager.Models;


namespace GameManager.Repository
{
    public class FakeRepository : IGameRepository
    {
        private readonly List<Game> _game = new()
    {
        new Game { Id = 1, Name = "Elden ring", Description = "Rpg", Year = 2022 },

        new Game { Id = 2, Name = "Devil may cry", Description = "Hack and slash ", Year = 2018 }
        ,
        new Game { Id = 3, Name = "Silent hill 2 ", Description = "Horror ", Year = 2024 },

        new Game { Id = 4, Name = "resident evil village ", Description = "Horror ", Year = 2020 }
    };

        public Task<IEnumerable<Game>> GetAllAsync()
        {
            // Vi skickar tillbaka listan direkt som en färdig Task
            return Task.FromResult<IEnumerable<Game>>(_game);
        }

        // Se till att det är ett litet 'd' i Id här:
        public Task<Game> GetByIdAsync(int id) => throw new NotImplementedException();

        public Task<Game> AddAsync(Game game) => throw new NotImplementedException();

        public Task DeleteAsync(int id) => throw new NotImplementedException();

        public Task UpdateAsync(Game game) => throw new NotImplementedException();
    }
}
