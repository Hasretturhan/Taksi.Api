using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _service;
        public AddressController(AddressService service)
        {
            _service = service;
        }

        // Tüm adresleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _service.GetAllAddressesAsync();
            return Ok(addresses);
        }

        // Belirli bir adresi getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var address = await _service.GetAddressByIdAsync(id);
            if (address == null) return NotFound();
            return Ok(address);
        }

        // Belirli bir yolcuya ait adresleri getir
        [HttpGet("passenger/{passengerId:int}")]
        public async Task<IActionResult> GetByPassenger(int passengerId)
        {
            var addresses = await _service.GetAddressesByPassengerIdAsync(passengerId);
            return Ok(addresses);
        }

        // Yeni adres ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Address address)
        {
            if (address is null) return BadRequest();
            await _service.AddAddressAsync(address);
            return Ok(address);
        }

        // Adres güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Address address)
        {
            if (address is null || id != address.Id) return BadRequest();
            await _service.UpdateAddressAsync(address);
            return Ok(address);
        }

        // Adres sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAddressAsync(id);
            return Ok();
        }
    }
}
