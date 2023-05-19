using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController<ILanguageService, Language, LanguageAddRequestModel, LanguageUpdateRequestModel, LanguageDeleteRequestModel>
    {
        public LanguagesController(ILanguageService service) : base(service)
        {
        }
    }
}
