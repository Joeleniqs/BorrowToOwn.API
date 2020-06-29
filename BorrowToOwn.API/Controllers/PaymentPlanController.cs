using System;
using System.Threading.Tasks;
using BorrowToOwn.Services.Communications.RequestObject.DTO;
using BorrowToOwn.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BorrowToOwn.API.Controllers
{
    [ApiController]
    [Route("/api/PaymentPlans")]
    public class PaymentPlanController : Controller
    {
        private readonly IPaymentPlanService _paymentPlanService;

        public PaymentPlanController(IPaymentPlanService paymentPlanService)
        {
            _paymentPlanService = paymentPlanService ?? throw new ArgumentNullException(nameof(paymentPlanService));

        }
        // GET: /<controller>/
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var cats = await _paymentPlanService.GetPaymentPlansAsync();

            return Ok(cats);
        }

        [HttpGet("{id:int}", Name = "GetPaymentPlan")]
        public async Task<IActionResult> GetPaymentPlan(int id)
        {
            var cat = await _paymentPlanService.GetPaymentPlanAsync(id);

            if (cat == null) return NotFound();

            return Ok(cat);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] PaymentPlanRequestObject PaymentPlanRequestObject)
        {
            var res = await _paymentPlanService.AddPaymentPlanAsync(PaymentPlanRequestObject);

            if (res == null) return BadRequest("Unable to create PaymentPlan at this time.");

            return CreatedAtRoute("GetPaymentPlan", new { id = res.Id }, res);

        }

        [HttpDelete("{id:int}/ToggleActive")]
        public async Task<IActionResult> TogglePaymentPlanActive(int id)
        {
            var check = await _paymentPlanService.IsPaymentPlanValidAsync(id);

            if (!check) return BadRequest("No Such PaymentPlan");

            var res = await _paymentPlanService.DeletePaymentPlanAsync(id);

            if (!res) return BadRequest("Unable to delete PaymentPlan at this time.");

            return NoContent();
        }

    }
}
