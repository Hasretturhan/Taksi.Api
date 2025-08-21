using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerService _service;
        public PassengerController(PassengerService service)
        {
            _service = service;
        }

        // Tüm yolcuları getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passengers = await _service.GetAllPassengersAsync();
            return Ok(passengers);
        }

        // Belirli bir yolcuyu getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var passenger = await _service.GetPassengerByIdAsync(id);
            if (passenger == null) return NotFound();
            return Ok(passenger);
        }

        // Yeni yolcu ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Passenger passenger)
        {
            if (passenger is null) return BadRequest();
            await _service.AddPassengerAsync(passenger);
            return Ok(passenger);
        }

        // Yolcu güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Passenger passenger)
        {
            if (passenger is null || id != passenger.Id) return BadRequest();
            await _service.UpdatePassengerAsync(passenger);
            return Ok(passenger);
        }

        // Yolcu sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePassengerAsync(id);
            return Ok();
        }
    }
}

