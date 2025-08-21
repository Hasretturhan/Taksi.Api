using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taksi.Data;
using Taksi.Data.Repository;
using Taksi.Entities;

namespace Taksi.Data.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly TaksiDbContext _context;
        public PassengerRepository(TaksiDbContext context)
        {
            _context = context;
        }

        public async Task<Passenger?> GetByIdAsync(int id)
        {
            return await _context.Passengers.FindAsync(id);
        }

        public async Task<List<Passenger>> GetAllAsync()
        {
            return await _context.Passengers.ToListAsync();
        }

        public async Task AddAsync(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
            }
        }
    }
}

