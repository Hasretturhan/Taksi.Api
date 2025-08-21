using Taksi.Entities;
using Taksi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Taksi.Data.Repository
{
    public class BonusRepository : IBonusRepository
    {
        private readonly TaksiDbContext _context;
        public BonusRepository(TaksiDbContext context)
        {
            _context = context;
        }

        public async Task<Bonus?> GetByIdAsync(int id)
        {
            return await _context.Bonuses.FindAsync(id);
        }

        public async Task<List<Bonus>> GetAllAsync()
        {
            return await _context.Bonuses.ToListAsync();
        }

        public async Task<List<Bonus>> GetByPassengerIdAsync(int passengerId)
        {
            return await _context.Bonuses
                .Where(b => b.PassengerId == passengerId)
                .ToListAsync();
        }

        public async Task AddAsync(Bonus bonus)
        {
            await _context.Bonuses.AddAsync(bonus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bonus bonus)
        {
            _context.Bonuses.Update(bonus);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bonus = await _context.Bonuses.FindAsync(id);
            if (bonus != null)
            {
                _context.Bonuses.Remove(bonus);
                await _context.SaveChangesAsync();
            }
        }
    }
}

