using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Business.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _repo;

        public PaymentService(IPaymentRepository repo)
        {
            _repo = repo;
        }

        // Tüm ödemeleri getir
        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir ödemeyi getir
        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Bir yolcuya ait ödemeleri getir
        public async Task<List<Payment>> GetPaymentsByPassengerIdAsync(int passengerId)
        {
            return await _repo.GetByPassengerIdAsync(passengerId);
        }

        // Yeni ödeme ekle (kart numarasını maskele)
        public async Task AddPaymentAsync(Payment payment)
        {
            payment.CardNumberMasked = MaskCardNumber(payment.CardNumberMasked);
            await _repo.AddAsync(payment);
        }

        // Ödeme güncelle (kart numarasını maskele)
        public async Task UpdatePaymentAsync(Payment payment)
        {
            payment.CardNumberMasked = MaskCardNumber(payment.CardNumberMasked);
            await _repo.UpdateAsync(payment);
        }

        // Ödeme sil
        public async Task DeletePaymentAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        // Kart numarasını maskeleme fonksiyonu
        private string? MaskCardNumber(string? cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 4)
                return cardNumber;

            var last4 = cardNumber.Substring(cardNumber.Length - 4);
            return new string('*', cardNumber.Length - 4) + last4;
        }
    }
}
