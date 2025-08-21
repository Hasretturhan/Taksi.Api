using Taksi.Entities;
using Taksi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Taksi.Data.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly TaksiDbContext _context;
        public CouponRepository(TaksiDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon?> GetByIdAsync(int id)
        {
            return await _context.Coupons.FindAsync(id);
        }

        public async Task<List<Coupon>> GetAllAsync()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<List<Coupon>> GetByPassengerIdAsync(int passengerId)
        {
            return await _context.Coupons
                .Where(c => c.PassengerId == passengerId)
                .ToListAsync();
        }

        public async Task<Coupon?> GetByCodeAsync(string code)
        {
            return await _context.Coupons
                .FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task AddAsync(Coupon coupon)
        {
            await _context.Coupons.AddAsync(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Coupon coupon)
        {
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
