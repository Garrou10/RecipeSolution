using MovieManager1.Models;

namespace MovieManager1.Repository
{
    public class FakeMovieRepository : IMovieRepository
    {
        // 1. Skapa listan här uppe så den sparas i minnet
        private readonly List<Movies> _movies = new()
    {
        new Movies { Id = 1, Title = "Game of Thrones", Director = "George RR Martin" }
    };

        // 2. Hämta alla filmer
        public async Task<IEnumerable<Movies>> GetAllAsync()
        {
            return await Task.FromResult(_movies);
        }

        // 3. Du MÅSTE lägga till de andra metoderna (tomma just nu är ok)
        // annars försvinner inte det röda strecket högst upp!
        public Task<Movies> GetByID(int id) => throw new NotImplementedException();
        public Task AddAsync(Movies movies) => throw new NotImplementedException();
        public Task UpdateAsync(Movies movies) => throw new NotImplementedException();
        public Task DeleteAsync(int id) => throw new NotImplementedException();
        public Task<IEnumerable<Movies>> SearchAsync(string term) => throw new NotImplementedException();
    }
}