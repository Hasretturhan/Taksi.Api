using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Business.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _repo;

        public VehicleService(IVehicleRepository repo)
        {
            _repo = repo;
        }

        // Tüm araçları getir
        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir aracı getir
        public async Task<Vehicle?> GetVehicleByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Bir sürücüye ait araçları getir
        public async Task<List<Vehicle>> GetVehiclesByDriverIdAsync(int driverId)
        {
            return await _repo.GetByDriverIdAsync(driverId);
        }

        // Yeni araç ekle
        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _repo.AddAsync(vehicle);
        }

        // Araç güncelle
        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            await _repo.UpdateAsync(vehicle);
        }

        // Araç sil
        public async Task DeleteVehicleAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
