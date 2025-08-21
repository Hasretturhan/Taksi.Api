using System;
using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taksi.Business.Services
{
    public class TripService
    {
        private readonly ITripRepository _repo;

        public TripService(ITripRepository repo)
        {
            _repo = repo;
        }

        // Tüm yolculukları getir
        public async Task<List<Trip>> GetAllTripsAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir yolculuğu getir
        public async Task<Trip?> GetTripByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Bir yolcuya ait yolculukları getir
        public async Task<List<Trip>> GetTripsByPassengerIdAsync(int passengerId)
        {
            return await _repo.GetByPassengerIdAsync(passengerId);
        }

        // Bir sürücüye ait yolculukları getir
        public async Task<List<Trip>> GetTripsByDriverIdAsync(int driverId)
        {
            return await _repo.GetByDriverIdAsync(driverId);
        }

        // Yeni yolculuk ekle (ücret hesaplanır)
        public async Task AddTripAsync(Trip trip)
        {
            trip.Fare = CalculateFare(trip.DistanceKm, trip.TaxiType);
            await _repo.AddAsync(trip);
        }

        // Yolculuk güncelle (ücret tekrar hesaplanır)
        public async Task UpdateTripAsync(Trip trip)
        {
            trip.Fare = CalculateFare(trip.DistanceKm, trip.TaxiType);
            await _repo.UpdateAsync(trip);
        }

        // Yolculuk sil
        public async Task DeleteTripAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        // Ücret hesaplama fonksiyonu (null/standart güvenli)
        private decimal CalculateFare(double distanceKm, string? taxiType)
        {
            var isVip = string.Equals(taxiType, "VIP", StringComparison.OrdinalIgnoreCase);
            decimal openingFee = isVip ? 60 : 40;
            decimal kmFee = isVip ? 15 : 10;
            decimal commission = 5;
            return openingFee + (decimal)distanceKm * kmFee + commission;
        }
    }
}
