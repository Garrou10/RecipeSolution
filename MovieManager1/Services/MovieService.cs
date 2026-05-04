using MovieManager1.Models;
using MovieManager1.Repository;

namespace MovieManager1.Services
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _movieService;

        public MovieService(IMovieRepository movieService)
        {
            _movieService = movieService;
        }

        public async Task<IEnumerable<Movies>> GetAllMoviesAsync()
        {
            return await _movieService.GetAllAsync();
        }

        public async Task<Movies?> GetMovieById(int id)
        {
            return await _movieService.GetByID(id);
        }

        public async Task<Movies> AddMovieAsync(Movies movies)
        {
            await _movieService.AddAsync(movies);
            return movies;
        }

        public async Task<IEnumerable<Movies>> SearchMoviesAsync(string query)
        {
            // Vi skickar frågan vidare till vårt repository
            return await _movieService.SearchAsync(query);
        }
public async Task DeleteMovieAsync(int id)
{
    // Vi bara väntar på att repositoryt tar bort den
    await _movieService.DeleteAsync(id);
}

        Task<Movies> IMovieService.SearchMoviesAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}





