using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : BaseController<IPurchaseService, Purchase, PurchaseAddRequestModel, PurchaseUpdateRequestModel, PurchaseDeleteRequestModel>
    {
        public PurchasesController(IPurchaseService service) : base(service)
        {
        }
    }
}
