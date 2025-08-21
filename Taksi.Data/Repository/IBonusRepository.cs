using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface IBonusRepository
    {
        Task<Bonus?> GetByIdAsync(int id);
        Task<List<Bonus>> GetAllAsync();
        Task<List<Bonus>> GetByPassengerIdAsync(int passengerId);
        Task AddAsync(Bonus bonus);
        Task UpdateAsync(Bonus bonus);
        Task DeleteAsync(int id);
    }
}
