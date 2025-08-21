using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Business.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _repo;

        public AddressService(IAddressRepository repo)
        {
            _repo = repo;
        }

        // Tüm adresleri getir
        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir adresi getir
        public async Task<Address?> GetAddressByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Bir yolcuya ait adresleri getir
        public async Task<List<Address>> GetAddressesByPassengerIdAsync(int passengerId)
        {
            return await _repo.GetByPassengerIdAsync(passengerId);
        }

        // Yeni adres ekle
        public async Task AddAddressAsync(Address address)
        {
            await _repo.AddAsync(address);
        }

        // Adres güncelle
        public async Task UpdateAddressAsync(Address address)
        {
            await _repo.UpdateAsync(address);
        }

        // Adres sil
        public async Task DeleteAddressAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
