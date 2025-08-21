using Taksi.Data.Repository;
using Taksi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Taksi.Business.Services
{
    public class SupportRequestService
    {
        private readonly ISupportRequestRepository _repo;

        public SupportRequestService(ISupportRequestRepository repo)
        {
            _repo = repo;
        }

        // Tüm destek taleplerini getir
        public async Task<List<SupportRequest>> GetAllRequestsAsync()
        {
            return await _repo.GetAllAsync();
        }

        // Belirli bir destek talebini getir
        public async Task<SupportRequest?> GetRequestByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        // Bir yolcuya ait destek taleplerini getir
        public async Task<List<SupportRequest>> GetRequestsByPassengerIdAsync(int passengerId)
        {
            return await _repo.GetByPassengerIdAsync(passengerId);
        }

        // Yeni destek talebi ekle
        public async Task AddRequestAsync(SupportRequest request)
        {
            request.RequestDate = DateTime.Now;
            request.IsResolved = false;
            await _repo.AddAsync(request);
        }

        // Destek talebini güncelle
        public async Task UpdateRequestAsync(SupportRequest request)
        {
            await _repo.UpdateAsync(request);
        }

        // Destek talebini sil
        public async Task DeleteRequestAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        // Destek talebini çözülmüş olarak işaretle
        public async Task MarkAsResolvedAsync(int id)
        {
            var request = await _repo.GetByIdAsync(id);
            if (request is null) return;

            request.IsResolved = true;
            await _repo.UpdateAsync(request);
        }
    }
}
