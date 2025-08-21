using Taksi.Entities;
using Taksi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Taksi.Data.Repository
{
    public class SupportRequestRepository : ISupportRequestRepository
    {
        private readonly TaksiDbContext _context;
        public SupportRequestRepository(TaksiDbContext context)
        {
            _context = context;
        }

        public async Task<SupportRequest?> GetByIdAsync(int id)
        {
            return await _context.SupportRequests.FindAsync(id);
        }

        public async Task<List<SupportRequest>> GetAllAsync()
        {
            return await _context.SupportRequests.ToListAsync();
        }

        public async Task<List<SupportRequest>> GetByPassengerIdAsync(int passengerId)
        {
            return await _context.SupportRequests
                .Where(r => r.PassengerId == passengerId)
                .ToListAsync();
        }

        public async Task AddAsync(SupportRequest request)
        {
            await _context.SupportRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SupportRequest request)
        {
            _context.SupportRequests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var request = await _context.SupportRequests.FindAsync(id);
            if (request != null)
            {
                _context.SupportRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
