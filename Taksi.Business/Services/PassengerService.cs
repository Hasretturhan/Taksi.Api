using System;
using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Taksi.Business.Services
{
    public class PassengerService
    {
        private readonly IPassengerRepository _repo;

        public PassengerService(IPassengerRepository repo)
        {
            _repo = repo;
        }

        // Tüm yolcuları getir
        public async Task<List<Passenger>> GetAllPassengersAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir yolcuyu getir
        public async Task<Passenger?> GetPassengerByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Yeni yolcu ekle (şifre hashlenir)
        public async Task AddPassengerAsync(Passenger passenger)
        {
            passenger.PasswordHash = HashPassword(passenger.PasswordHash);
            await _repo.AddAsync(passenger);
        }

        // Yolcu güncelle (şifre değişirse hashlenir)
        public async Task UpdatePassengerAsync(Passenger passenger)
        {
            passenger.PasswordHash = HashPassword(passenger.PasswordHash);
            await _repo.UpdateAsync(passenger);
        }

        //Yolcu sil
        public async Task DeletePassengerAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        // Şifre hashleme fonksiyonu (nullable guard ile)
        private string HashPassword(string? password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.", nameof(password));

            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
