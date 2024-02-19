using Application.Features.Auth.Commands.AuthRefreshToken;
using Application.Features.Auth.Commands.Login.LoginByEmail;
using Application.Features.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("LoginByEmail")]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailModel model)
        {
            var result = await Mediator.Send(new LoginByEmailCommand { Email = model.Email, Password = model.Password, IpAdress = GetIpAddress()! });

            return Ok(result);
        }

        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var command = new RefreshTokenCommand
            {
                IpAddress = GetIpAddress(),
                RefreshToken = GetRefreshTokenFromCookies()
            };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        private string? GetRefreshTokenFromCookies()
        {
            return Request.Cookies["refreshToken"];
        }
    }
}