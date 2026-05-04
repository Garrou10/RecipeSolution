using MovieManager1.Models;

namespace MovieManager1.Repository
{
    public interface IMovieRepository
    {
        Task <IEnumerable<Movies>> GetAllAsync();

        Task <Movies> GetByID(int id);

        Task AddAsync (Movies movies);

        Task UpdateAsync (Movies movies);
        Task DeleteAsync (int Id);

        Task<IEnumerable<Movies>> SearchAsync(string term);


    }


    
}
