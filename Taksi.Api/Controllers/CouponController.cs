using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly CouponService _service;
        public CouponController(CouponService service)
        {
            _service = service;
        }

        // Tüm kuponları getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coupons = await _service.GetAllCouponsAsync();
            return Ok(coupons);
        }

        // Belirli bir kuponu getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var coupon = await _service.GetCouponByIdAsync(id);
            if (coupon == null) return NotFound();
            return Ok(coupon);
        }

        // Bir yolcuya ait kuponları getir
        [HttpGet("passenger/{passengerId:int}")]
        public async Task<IActionResult> GetByPassenger(int passengerId)
        {
            var coupons = await _service.GetCouponsByPassengerIdAsync(passengerId);
            return Ok(coupons);
        }

        // Kupon koduna göre getir
        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var coupon = await _service.GetCouponByCodeAsync(code);
            if (coupon == null) return NotFound();
            return Ok(coupon);
        }

        // Yeni kupon ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Coupon coupon)
        {
            if (coupon is null) return BadRequest();
            await _service.AddCouponAsync(coupon);
            return Ok(coupon);
        }

        // Kupon güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Coupon coupon)
        {
            if (coupon is null || id != coupon.Id) return BadRequest();
            await _service.UpdateCouponAsync(coupon);
            return Ok(coupon);
        }

        // Kupon sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCouponAsync(id);
            return Ok();
        }

        // Kuponun geçerli olup olmadığını kontrol et
        [HttpGet("validate/{id:int}")]
        public async Task<IActionResult> Validate(int id)
        {
            var coupon = await _service.GetCouponByIdAsync(id);
            if (coupon == null) return NotFound();
            var isValid = _service.IsCouponValid(coupon);
            return Ok(new { coupon.Id, coupon.Code, IsValid = isValid });
        }
    }
}
