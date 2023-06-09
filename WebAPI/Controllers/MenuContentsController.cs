﻿using Business.Abstract;
using Core.WebAPI;
using Entities.Concrete;
using Entities.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuContentsController : BaseController<IMenuContentService, MenuContent, MenuContentAddRequestModel, MenuContentUpdateRequestModel, MenuContentDeleteRequestModel>
    {
        public MenuContentsController(IMenuContentService service) : base(service)
        {
        }
    }
}
