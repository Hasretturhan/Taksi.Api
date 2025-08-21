using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface ITripRepository
    {
        Task<Trip?> GetByIdAsync(int id);
        Task<List<Trip>> GetAllAsync();
        Task<List<Trip>> GetByPassengerIdAsync(int passengerId);
        Task<List<Trip>> GetByDriverIdAsync(int driverId);
        Task AddAsync(Trip trip);
        Task UpdateAsync(Trip trip);
        Task DeleteAsync(int id);
    }
}
