using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface IPassengerRepository
    {
        Task<Passenger?> GetByIdAsync(int id);
        Task<List<Passenger>> GetAllAsync();
        Task AddAsync(Passenger passenger);
        Task UpdateAsync(Passenger passenger);
        Task DeleteAsync(int id);
    }
}

