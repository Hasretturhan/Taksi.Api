using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface IAddressRepository
    {
        Task<Address?> GetByIdAsync(int id);
        Task<List<Address>> GetAllAsync();
        Task<List<Address>> GetByPassengerIdAsync(int passengerId);
        Task AddAsync(Address address);
        Task UpdateAsync(Address address);
        Task DeleteAsync(int id);
    }
}

