using Microsoft.AspNetCore.Mvc;
using Taksi.Business.Services;
using Taksi.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Taksi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _service;
        public PaymentController(PaymentService service)
        {
            _service = service;
        }

        // Tüm ödemeleri getir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _service.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // Belirli bir ödemeyi getir
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var payment = await _service.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        // Belirli bir yolcuya ait ödemeleri getir
        [HttpGet("passenger/{passengerId:int}")]
        public async Task<IActionResult> GetByPassenger(int passengerId)
        {
            var payments = await _service.GetPaymentsByPassengerIdAsync(passengerId);
            return Ok(payments);
        }

        // Yeni ödeme ekle
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Payment payment)
        {
            if (payment is null) return BadRequest();
            await _service.AddPaymentAsync(payment);
            return Ok(payment);
        }

        // Ödeme güncelle
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Payment payment)
        {
            if (payment is null || id != payment.Id) return BadRequest();
            await _service.UpdatePaymentAsync(payment);
            return Ok(payment);
        }

        // Ödeme sil
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePaymentAsync(id);
            return Ok();
        }
    }
}
