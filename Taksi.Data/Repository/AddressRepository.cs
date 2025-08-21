using Taksi.Entities;
using Taksi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Taksi.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly TaksiDbContext _context;
        public AddressRepository(TaksiDbContext context)
        {
            _context = context;
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<List<Address>> GetByPassengerIdAsync(int passengerId)
        {
            return await _context.Addresses
                .Where(a => a.PassengerId == passengerId)
                .ToListAsync();
        }

        public async Task AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
