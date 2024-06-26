﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoleBased.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Index() => "Index Route";

        [HttpGet("/secret")]
        [Authorize(Roles = "admin")]
        public string Secret() => "Secret Route";
    }
}
