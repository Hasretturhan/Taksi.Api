using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly TripService _service;
        public TripController(TripService service)
        {
            _service = service;
        }

        // Tüm yolculukları getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trips = await _service.GetAllTripsAsync();
            return Ok(trips);
        }

        // Belirli bir yolculuğu getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var trip = await _service.GetTripByIdAsync(id);
            if (trip == null) return NotFound();
            return Ok(trip);
        }

        // Belirli bir yolcuya ait yolculukları getir
        [HttpGet("passenger/{passengerId:int}")]
        public async Task<IActionResult> GetByPassenger(int passengerId)
        {
            var trips = await _service.GetTripsByPassengerIdAsync(passengerId);
            return Ok(trips);
        }

        // Belirli bir sürücüye ait yolculukları getir
        [HttpGet("driver/{driverId:int}")]
        public async Task<IActionResult> GetByDriver(int driverId)
        {
            var trips = await _service.GetTripsByDriverIdAsync(driverId);
            return Ok(trips);
        }

        // Yeni yolculuk ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Trip trip)
        {
            if (trip is null) return BadRequest();
            await _service.AddTripAsync(trip);
            return Ok(trip);
        }

        // Yolculuk güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Trip trip)
        {
            if (trip is null || id != trip.Id) return BadRequest();
            await _service.UpdateTripAsync(trip);
            return Ok(trip);
        }

        // Yolculuk sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTripAsync(id);
            return Ok();
        }
    }
}
