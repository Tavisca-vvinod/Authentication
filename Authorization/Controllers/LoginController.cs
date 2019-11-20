using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Models;
using Authorization.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private LoginService _service;
        public LoginController(LoginService service)
        {
            _service = service;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginCredintials)
        {
            User user = _service.Validate(loginCredintials);
            if(user!=null)
            {
                return Ok(_service.GenarateToken(user));
            }
            return BadRequest("Invalid Credintials");

        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
