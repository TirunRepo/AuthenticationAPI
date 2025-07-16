using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController() { }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok();
        }
    }
}
