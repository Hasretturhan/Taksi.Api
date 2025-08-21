using Taksi.Entities;
using Taksi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Taksi.Data.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly TaksiDbContext _context;
        public TripRepository(TaksiDbContext context)
        {
            _context = context;
        }

        public async Task<Trip?> GetByIdAsync(int id)
        {
            return await _context.Trips.FindAsync(id);
        }

        public async Task<List<Trip>> GetAllAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<List<Trip>> GetByPassengerIdAsync(int passengerId)
        {
            return await _context.Trips
                .Where(t => t.PassengerId == passengerId)
                .ToListAsync();
        }

        public async Task<List<Trip>> GetByDriverIdAsync(int driverId)
        {
            return await _context.Trips
                .Where(t => t.DriverId == driverId)
                .ToListAsync();
        }

        public async Task AddAsync(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
        }
    }
}
