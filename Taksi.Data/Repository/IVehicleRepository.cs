using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> GetByIdAsync(int id);
        Task<List<Vehicle>> GetAllAsync();
        Task<List<Vehicle>> GetByDriverIdAsync(int driverId);
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
        Task DeleteAsync(int id);
    }
}
