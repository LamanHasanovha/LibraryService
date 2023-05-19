using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Services;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentsController()
        {
            _paymentService = new PaymentService();
        }

        [HttpPost]
        public IActionResult Get()
        {
            _paymentService.GenerateHtml(new PaymentModel());
            return Ok();
        }
    }
}
