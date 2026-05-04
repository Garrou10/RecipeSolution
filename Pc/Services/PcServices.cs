using Pc.Repositories;
using Pc.Models;
namespace Pc.Services
{
    public class PcServices : IPcServices
    {
        private readonly IPc _pc;

        public PcServices(IPc pc) {
            _pc = pc;
        }

        public async Task<IEnumerable<Computer>> GetAllPcAsync() 
        {
            return await _pc.GetAllAsync();
        }
        public async Task<Computer> GetByPcIdAsync(int id )
        {
            return await _pc.GetByIdAsync(id);
        }
        public async Task AddPcAsync(Computer computer)
        {

             await _pc.AddAsync(computer);
             
        }

        public async Task UpdatePcAsync(Computer computer)
        {
             await _pc.UpdateAsync(computer);
        }

        public async Task DeletePcAsync(int id)
        {
            await _pc.DeleteAsync(id);
        }

    }
}
