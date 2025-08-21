using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _service;
        public DriverController(DriverService service)
        {
            _service = service;
        }

        // Tüm sürücüleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drivers = await _service.GetAllDriversAsync();
            return Ok(drivers);
        }

        // Belirli bir sürücüyü getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var driver = await _service.GetDriverByIdAsync(id);
            if (driver == null) return NotFound();
            return Ok(driver);
        }

        // Yeni sürücü ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Driver driver)
        {
            if (driver is null) return BadRequest();
            await _service.AddDriverAsync(driver);
            return Ok(driver);
        }

        // Sürücü güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Driver driver)
        {
            if (driver is null || id != driver.Id) return BadRequest();
            await _service.UpdateDriverAsync(driver);
            return Ok(driver);
        }

        // Sürücü sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteDriverAsync(id);
            return Ok();
        }
    }
}
