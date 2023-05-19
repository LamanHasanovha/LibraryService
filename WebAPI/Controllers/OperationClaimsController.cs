using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Models;
using Core.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController<IOperationClaimService, OperationClaim, OperationClaimAddRequestModel, OperationClaimUpdateRequestModel, OperationClaimDeleteRequestModel>
    {
        public OperationClaimsController(IOperationClaimService service) : base(service)
        {
        }
    }
}
