using Microsoft.AspNetCore.Mvc;

namespace final_project.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new
            {
                message = "API is working!",
                success = true
            });
        }
    }
}