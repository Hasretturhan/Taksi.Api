using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Taksi.Business.Services
{
    public class CouponService
    {
        private readonly ICouponRepository _repo;

        public CouponService(ICouponRepository repo)
        {
            _repo = repo;
        }

        // Tüm kuponları getir
        public async Task<List<Coupon>> GetAllCouponsAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir kuponu getir
        public async Task<Coupon?> GetCouponByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Bir yolcuya ait kuponları getir
        public async Task<List<Coupon>> GetCouponsByPassengerIdAsync(int passengerId)
        {
            return await _repo.GetByPassengerIdAsync(passengerId);
        }

        // Kupon koduna göre getir
        public async Task<Coupon?> GetCouponByCodeAsync(string code)
        {
            return await _repo.GetByCodeAsync(code);
        }

        // Yeni kupon ekle
        public async Task AddCouponAsync(Coupon coupon)
        {
            await _repo.AddAsync(coupon);
        }

        // Kupon güncelle
        public async Task UpdateCouponAsync(Coupon coupon)
        {
            await _repo.UpdateAsync(coupon);
        }

        // Kupon sil
        public async Task DeleteCouponAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        // Kuponun geçerli olup olmadığını kontrol et
        public bool IsCouponValid(Coupon coupon)
        {
            return coupon.ExpiryDate > DateTime.Now;
        }
    }
}
