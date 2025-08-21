using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SupportRequestController : ControllerBase
    {
        private readonly SupportRequestService _service;
        public SupportRequestController(SupportRequestService service)
        {
            _service = service;
        }

        // Tüm destek taleplerini getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _service.GetAllRequestsAsync();
            return Ok(requests);
        }

        // Belirli bir destek talebini getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = await _service.GetRequestByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        // Bir yolcuya ait destek taleplerini getir
        [HttpGet("passenger/{passengerId:int}")]
        public async Task<IActionResult> GetByPassenger(int passengerId)
        {
            var requests = await _service.GetRequestsByPassengerIdAsync(passengerId);
            return Ok(requests);
        }

        // Yeni destek talebi ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SupportRequest request)
        {
            if (request is null) return BadRequest();
            await _service.AddRequestAsync(request);
            return Ok(request);
        }

        // Destek talebini güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupportRequest request)
        {
            if (request is null || id != request.Id) return BadRequest();
            await _service.UpdateRequestAsync(request);
            return Ok(request);
        }

        // Destek talebini sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRequestAsync(id);
            return Ok();
        }

        // Destek talebini çözülmüş olarak işaretle
        [HttpPut("resolve/{id:int}")]
        public async Task<IActionResult> MarkAsResolved(int id)
        {
            await _service.MarkAsResolvedAsync(id);
            return Ok();
        }
    }
}
