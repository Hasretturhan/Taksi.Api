using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _service;
        public VehicleController(VehicleService service)
        {
            _service = service;
        }

        // Tüm araçları getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _service.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        // Belirli bir aracı getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await _service.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();
            return Ok(vehicle);
        }

        // Belirli bir sürücüye ait araçları getir
        [HttpGet("driver/{driverId:int}")]
        public async Task<IActionResult> GetByDriver(int driverId)
        {
            var vehicles = await _service.GetVehiclesByDriverIdAsync(driverId);
            return Ok(vehicles);
        }

        // Yeni araç ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Vehicle vehicle)
        {
            if (vehicle is null) return BadRequest();
            await _service.AddVehicleAsync(vehicle);
            return Ok(vehicle);
        }

        // Araç güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle)
        {
            if (vehicle is null || id != vehicle.Id) return BadRequest();
            await _service.UpdateVehicleAsync(vehicle);
            return Ok(vehicle);
        }

        // Araç sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteVehicleAsync(id);
            return Ok();
        }
    }
}
