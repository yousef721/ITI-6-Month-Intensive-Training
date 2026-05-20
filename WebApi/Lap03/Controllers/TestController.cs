using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lap03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Authorized User");
        }

        [HttpGet("employee")]
        [Authorize(Roles = "employee")]
        public IActionResult EmployeeOnly()
        {
            return Ok("Employee Only");
        }
    }
}