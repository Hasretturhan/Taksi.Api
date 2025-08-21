using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface ISupportRequestRepository
    {
        Task<SupportRequest?> GetByIdAsync(int id);
        Task<List<SupportRequest>> GetAllAsync();
        Task<List<SupportRequest>> GetByPassengerIdAsync(int passengerId);
        Task AddAsync(SupportRequest request);
        Task UpdateAsync(SupportRequest request);
        Task DeleteAsync(int id);
    }
}
