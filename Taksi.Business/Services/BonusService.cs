using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Business.Services
{
    public class BonusService
    {
        private readonly IBonusRepository _repo;

        public BonusService(IBonusRepository repo)
        {
            _repo = repo;
        }

        // Tüm bonusları getir
        public async Task<List<Bonus>> GetAllBonusesAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir bonusu getir
        public async Task<Bonus?> GetBonusByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Bir yolcuya ait bonusları getir
        public async Task<List<Bonus>> GetBonusesByPassengerIdAsync(int passengerId)
        {
            return await _repo.GetByPassengerIdAsync(passengerId);
        }

        // Yeni bonus ekle
        public async Task AddBonusAsync(Bonus bonus)
        {
            await _repo.AddAsync(bonus);
        }

        // Bonus güncelle
        public async Task UpdateBonusAsync(Bonus bonus)
        {
            await _repo.UpdateAsync(bonus);
        }

        // Bonus sil
        public async Task DeleteBonusAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
