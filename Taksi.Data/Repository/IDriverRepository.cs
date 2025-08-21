using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface IDriverRepository
    {
        Task<Driver?> GetByIdAsync(int id);
        Task<List<Driver>> GetAllAsync();
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
        Task DeleteAsync(int id);
    }
}
