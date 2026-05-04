using MovieManager1.Models;

namespace MovieManager1.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movies>> GetAllMoviesAsync();
        Task <Movies?> GetMovieById(int id);
        Task<Movies> AddMovieAsync(Movies movies);

        Task<Movies> SearchMoviesAsync( string query);

        Task DeleteMovieAsync(int id);
    }
}
