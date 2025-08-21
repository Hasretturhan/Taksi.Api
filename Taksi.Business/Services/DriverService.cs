using System;
using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Taksi.Business.Services
{
    public class DriverService
    {
        private readonly IDriverRepository _repo;

        public DriverService(IDriverRepository repo)
        {
            _repo = repo;
        }

        // Tüm sürücüleri getir
        public async Task<List<Driver>> GetAllDriversAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir sürücüyü getir
        public async Task<Driver?> GetDriverByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Yeni sürücü ekle (şifre hashlenir)
        public async Task AddDriverAsync(Driver driver)
        {
            driver.PasswordHash = HashPassword(driver.PasswordHash);
            await _repo.AddAsync(driver);
        }

        // Sürücü güncelle (şifre değişirse hashlenir)
        public async Task UpdateDriverAsync(Driver driver)
        {
            driver.PasswordHash = HashPassword(driver.PasswordHash);
            await _repo.UpdateAsync(driver);
        }

        // Sürücü sil
        public async Task DeleteDriverAsync(int id)
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
