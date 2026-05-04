using Pc.Models;

namespace Pc.Repositories
{
    public interface IPc
    {
        Task<IEnumerable<Computer>> GetAllAsync();
        Task<Computer?> GetByIdAsync(int id);
        Task  AddAsync (Computer computer);
        Task UpdateAsync (Computer computer);
        Task DeleteAsync (int id);



    }
}
