using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RnD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> CurrentDateTime()
        {
            var response = await Task.FromResult(DateTime.Now.ToLongDateString());
            return Ok(response);
        }
    }
}
