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

        [HttpPost("pay")]
        public IActionResult Get(PaymentModel model)
        {
            var result = _paymentService.DoPayment(model);
            return new FileStreamResult(result, "application/pdf")
            {
                FileDownloadName = "Invoice"
            };
        }
    }
}
