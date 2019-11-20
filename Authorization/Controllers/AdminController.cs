using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            return Ok("u have permission to access ADMIN");
        }
    }
}