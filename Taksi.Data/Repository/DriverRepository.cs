using Taksi.Entities;
using Taksi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Data.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly TaksiDbContext _context;
        public DriverRepository(TaksiDbContext context)
        {
            _context = context;
        }

        public async Task<Driver?> GetByIdAsync(int id)
        {
            return await _context.Drivers.FindAsync(id);
        }

        public async Task<List<Driver>> GetAllAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task AddAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Driver driver)
        {
            _context.Drivers.Update(driver);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                await _context.SaveChangesAsync();
            }
        }
    }
}
