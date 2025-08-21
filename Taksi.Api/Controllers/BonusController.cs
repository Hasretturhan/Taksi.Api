using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BonusController : ControllerBase
    {
        private readonly BonusService _service;
        public BonusController(BonusService service)
        {
            _service = service;
        }

        // Tüm bonusları getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bonuses = await _service.GetAllBonusesAsync();
            return Ok(bonuses);
        }

        // Belirli bir bonusu getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var bonus = await _service.GetBonusByIdAsync(id);
            if (bonus == null) return NotFound();
            return Ok(bonus);
        }

        // Bir yolcuya ait bonusları getir
        [HttpGet("passenger/{passengerId:int}")]
        public async Task<IActionResult> GetByPassenger(int passengerId)
        {
            var bonuses = await _service.GetBonusesByPassengerIdAsync(passengerId);
            return Ok(bonuses);
        }

        // Yeni bonus ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Bonus bonus)
        {
            if (bonus is null) return BadRequest();
            await _service.AddBonusAsync(bonus);
            return Ok(bonus);
        }

        // Bonus güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Bonus bonus)
        {
            if (bonus is null || id != bonus.Id) return BadRequest();
            await _service.UpdateBonusAsync(bonus);
            return Ok(bonus);
        }

        // Bonus sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteBonusAsync(id);
            return Ok();
        }
    }
}
