using MediatR;
using Microsoft.AspNetCore.Mvc;
using RnD.API.Commands;
using RnD.API.Infrastructures.Auth;
using RnD.API.Request;

namespace RnD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController (ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        /// <summary>
        /// login request
        /// </summary>
        /// <param name="request"></param>
        /// <returns>token</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = new AuthCommand(request.Email);
            var response = await _sender.Send(command);
            return Ok(response);
        }
    }
}
