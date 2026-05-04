using Pc.Models;
namespace Pc.Repositories
{
    public class FakeRepository : IPc
    {
        public async Task<IEnumerable<Computer>> GetAllAsync() => new List<Computer> { new Computer { Id = 1, Name = "Rtx-2070" } };

        public async Task<Computer?> GetByIdAsync(int id) => null;
        public async Task AddAsync(Computer computer) { }
        public async Task UpdateAsync(Computer computer) { }
        public Task DeleteAsync(int id)
        {
            return Task.CompletedTask;
        }
    }
}
