using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RnD.API.Options;
using Shared.Converters;

namespace RnD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController
        (
            IOptions<LoggerOption> logger
        )
        : ControllerBase
    {
        private readonly LoggerOption _logger = logger.Value;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> CurrentDateTime()
        {
            var response = await Task.FromResult(DateTime.Now.ToLongDateString());
            return Ok(response);
        }

        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetStatusAsync([FromQuery] string param)
        {
            param = param.ToLower();

            var response = param switch
            {
                "logger" => _logger.EnableLog ? "Enabled" : "Disabled",
                _ => throw new NotImplementedException()
            };

            return Ok(await Task.FromResult(response));
        }
        [HttpGet]
        [Route("converter")]
        public async Task<IActionResult> ConvertTimeToSecond([FromQuery] string param)
        {
            param = param.ToLower().Trim();

            var response = string.Concat(TimeConverter.ConvertToSeconds(param), 's');

            return Ok(await Task.FromResult(response));
        }
    }
}
