using Pc.Models;
namespace Pc.Services
{
    public interface IPcServices
    {
        Task<IEnumerable<Computer>> GetAllPcAsync();

        Task<Computer?> GetByPcIdAsync(int id);
        Task AddPcAsync(Computer computer);
        Task UpdatePcAsync(Computer computer);
        Task DeletePcAsync(int id);

    }
}
