using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuObjectsController : BaseController<IMenuObjectService, MenuObject, MenuObjectAddRequestModel, MenuObjectUpdateRequestModel, MenuObjectDeleteRequestModel>
    {
        public MenuObjectsController(IMenuObjectService service) : base(service)
        {
        }

        [HttpGet("getbycontent")]
        public async Task<IActionResult> GetByContent(int id)
        {
            return Ok(await Service.GetByContent(id));
        }
    }
}
