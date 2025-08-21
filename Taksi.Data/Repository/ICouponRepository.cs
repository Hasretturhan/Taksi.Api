using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public interface ICouponRepository
    {
        Task<Coupon?> GetByIdAsync(int id);
        Task<List<Coupon>> GetAllAsync();
        Task<List<Coupon>> GetByPassengerIdAsync(int passengerId);
        Task<Coupon?> GetByCodeAsync(string code);
        Task AddAsync(Coupon coupon);
        Task UpdateAsync(Coupon coupon);
        Task DeleteAsync(int id);
    }
}
